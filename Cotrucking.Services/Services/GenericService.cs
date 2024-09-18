using AutoMapper;
using Cotrucking.Infrastructure;
using Cotrucking.Domain.Constants;
using Cotrucking.Domain.Exceptions;
using Cotrucking.Domain.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System.Linq.Expressions;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Cotrucking.Services;
public interface IGenericService<DataModel, Response> where DataModel : class where Response : class
{
    Task<Response> GetByIdAsync(Guid id);
    Task<Response> FirstOrDefaultAsync(Expression<Func<DataModel, bool>> expression);
    Task<IEnumerable<Response>> GetAllAsync();
    Task<IEnumerable<KeyValueModel>> GetKeyValueAsync();
    Task<IEnumerable<Response>> FindByAsync<Input>(Expression<Func<Input, bool>> expression);
    Task<ResponseModel<Response>> GetAllByPage<Search>(RequestModel<Search> filters);
    Task<Response> AddAsync<Input>(Input entity);
    Task<bool> AddRange<Input>(List<Input> entities);
    Task<bool> Delete(Guid id);
    Task<bool> RemoveRange<Input>(List<Input> entities);
    Task<bool> Update<Input>(Input entity, Guid id);
    Task<int> SaveChanges();
    Task<byte[]> ExporttoExcel<Input>(Expression<Func<Input, bool>> expression, string? filename);
    Task<bool> UploadFile(IFormFile file);
}

public class GenericService<DataModel, Response>(IGenericRepository<DataModel> repository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : IGenericService<DataModel, Response> where DataModel : class where Response : class
{
    public async Task<Response> GetByIdAsync(Guid id)
    {
        DataModel? Objet = await repository.FindAsync(id);
        return Objet == null ? throw new ResponseException(ErrorConstants.NotFound) : mapper.Map<Response>(Objet);
    }

    public async Task<Response> FirstOrDefaultAsync(Expression<Func<DataModel, bool>> expression)
    {
        DataModel? Objet = await repository.FindFirstOrDefaultAsync(expression);
        return Objet == null ? throw new ResponseException(ErrorConstants.NotFound) : mapper.Map<Response>(Objet);
    }

    public async Task<IEnumerable<Response>> GetAllAsync()
    {
        var entities = await repository.GetAllAsNoTrackingAsync();
        return mapper.ProjectTo<Response>(entities);
    }

    public virtual async Task<IEnumerable<KeyValueModel>> GetKeyValueAsync()
    {
        return mapper.Map<IEnumerable<DataModel>, IEnumerable<KeyValueModel>>(await repository.GetAllAsync());
    }

    public async Task<IEnumerable<Response>> FindByAsync<Input>(Expression<Func<Input, bool>> expression)
    {
        Expression<Func<DataModel, bool>> repoExpression = mapper.Map<Expression<Func<Input, bool>>, Expression<Func<DataModel, bool>>>(expression);
        return mapper.Map<IEnumerable<DataModel>, IEnumerable<Response>>(await repository.FindAsync(repoExpression));
    }

    public async Task<IQueryable<Response>> FindBy<Input>(Expression<Func<Input, bool>> expression)
    {
        Expression<Func<DataModel, bool>> repoExpression = mapper.Map<Expression<Func<Input, bool>>, Expression<Func<DataModel, bool>>>(expression);
        return mapper.Map<IQueryable<DataModel>, IQueryable<Response>>(await repository.FindAsync(repoExpression));
    }

    public async Task<ResponseModel<Response>> GetAllByPage<Search>(RequestModel<Search> filters)
    {
        var res = await repository.GetAllAsNoTrackingAsync();
        var response = new ResponseModel<Response>()
        {
            Count = await res.CountAsync(),
            Items = mapper.ProjectTo<Response>(res.Skip(filters.PageSize * (filters.Page - 1)).Take(filters.PageSize))
        };
        return response;
    }

    /// <summary>
    /// Add entity and return added entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual async Task<Response> AddAsync<Input>(Input entity)
    {
        var repoEntity = mapper.Map<DataModel>(entity);
        await repository.InsertAsync(repoEntity);
        await repository.SaveChangesAsync();
        return mapper.Map<Response>(repoEntity);
    }

    public virtual async Task<bool> AddRange<Input>(List<Input> entities)
    {
        List<DataModel> repoEntities = mapper.Map<List<Input>, List<DataModel>>(entities);
        await repository.InsertRangeAsync(repoEntities);
        return true;
    }

    public async Task<bool> Update<Input>(Input entity, Guid id)
    {
        DataModel repoEntity = mapper.Map<Input, DataModel>(entity);
        await repository.UpdateAsync(repoEntity);
        return await repository.SaveChangesAsync() > 0;
    }

    public async Task<bool> Delete(Guid id)
    {
        DataModel? entity = await repository.FindAsync(id);
        if (entity == null) throw new ResponseException(ErrorConstants.NotFound);
        await repository.DeleteAsync(entity);
        return await repository.SaveChangesAsync() > 0;
    }


    public async Task<bool> RemoveRange<Input>(List<Input> entities)
    {
        List<DataModel> repoEntities = mapper.Map<List<Input>, List<DataModel>>(entities);
        await repository.DeleteRangeAsync(repoEntities);
        return true;
    }

    public async Task<int> SaveChanges()
    {
        return await repository.SaveChangesAsync();
    }

    public async Task<byte[]> ExporttoExcel<Input>(Expression<Func<Input, bool>> expression, string? filename)
    {
        var res = await repository.GetAllAsNoTrackingAsync();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using ExcelPackage pack = new();
        ExcelWorksheet ws = pack.Workbook.Worksheets.Add(filename ?? string.Empty);
        ws.Cells["A1"].LoadFromCollection(res, true, TableStyles.Light1).AutoFitColumns();
        return await Task.FromResult(pack.GetAsByteArray());
    }

    public async Task<bool> UploadFile(IFormFile file)
    {
        var pathenv = Path.GetTempPath();
        string path = Path.Combine(pathenv, "uploads", $"{Guid.NewGuid()}_{file.FileName}");
        await using FileStream fs = new(path, FileMode.Create);
        await file.CopyToAsync(fs);
        return true;
    }
}
