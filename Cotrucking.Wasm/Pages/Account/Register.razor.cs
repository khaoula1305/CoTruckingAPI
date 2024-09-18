using Cotrucking.Wasm.Constant;
using Cotrucking.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Cotrucking.Domain.Models;

namespace Cotrucking.Wasm.Pages.Account
{
    public class RegisterBase : ComponentBase
    {
        [Inject]
        public ITransporterService TransporterService { get; set; }

        public TransporterModel employee = new TransporterModel();

        public async Task OnSubmit()
        {
            // Save employee to the database
            await SaveTransporterToDatabase(employee);
        }

        protected async Task OnFileChange(Object args)
        {
            // Convert file to byte array and store in employee.Photo
            using (var ms = new MemoryStream())
            {
                //await args.File.OpenReadStream().CopyToAsync(ms);
                employee.Photo = ms.ToArray();
            }
        }

        protected async Task SaveTransporterToDatabase(TransporterModel employee)
        {
            // Here you will add the logic to save the employee (transporter) to the database
            // This may involve calling a service that interacts with your database

            await TransporterService.Insert(Endpoints.Transporters, employee);
        }


        protected bool IsPasswordComplex(string password)
        {
            return password.Any(char.IsDigit) && password.Any(char.IsLower) && password.Any(char.IsUpper) && password.Length > 8 && password.Any(char.IsSymbol);
        }
    }

}
