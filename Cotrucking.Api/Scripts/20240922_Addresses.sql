-- Inserting into countries (Country)
INSERT INTO countries (Id, Name, CountryCode, CreatedDate, ModifiedDate, CreatedBy)
VALUES 
  ('e0a5645c-974d-4dfe-b7cc-d218444d6cc5', 'Morocco', 'MA', GETDATE(), GETDATE(), '00000000-0000-0000-0000-000000000000');

-- Get the Id for Morocco (we already know it since it's hardcoded)
DECLARE @CountryId UNIQUEIDENTIFIER;
SET @CountryId = 'e0a5645c-974d-4dfe-b7cc-d218444d6cc5';

-- Inserting into cities (Cities: Casablanca, Rabat) using the same GUID
INSERT INTO cities (Id, Name, CountryId, CreatedDate, ModifiedDate, CreatedBy)
VALUES 
  ('e0a5645c-974d-4dfe-b7cc-d218444d6cc5', 'Casablanca', @CountryId, GETDATE(), GETDATE(), '00000000-0000-0000-0000-000000000000'),
  ('e0a5645c-974d-4dfe-b7cc-d218444d6cc6', 'Rabat', @CountryId, GETDATE(), GETDATE(), '00000000-0000-0000-0000-000000000000');

-- Get the Ids for Casablanca and Rabat (both using the same GUID)
DECLARE @CasablancaId UNIQUEIDENTIFIER;
DECLARE @RabatId UNIQUEIDENTIFIER;
SET @CasablancaId = 'e0a5645c-974d-4dfe-b7cc-d218444d6cc5';
SET @RabatId = 'e0a5645c-974d-4dfe-b7cc-d218444d6cc6';

-- Inserting into addresses (Addresses: Sidi Maarouf, Hay Riad, and more)
INSERT INTO addresses (Id, CityId, Region, PostalCode, Address, CreatedDate, ModifiedDate, CreatedBy)
VALUES 
  -- Casablanca Addresses
  (NEWID(), @CasablancaId, 'Sidi Maarouf', '20190', '123 Avenue Sidi Maarouf', GETDATE(), GETDATE(), '00000000-0000-0000-0000-000000000000'),
  (NEWID(), @CasablancaId, 'Maarif', '20250', '789 Boulevard Al Massira Al Khadra', GETDATE(), GETDATE(), '00000000-0000-0000-0000-000000000000'),
  (NEWID(), @CasablancaId, 'Ain Diab', '20180', '456 Route d''Ain Diab', GETDATE(), GETDATE(), '00000000-0000-0000-0000-000000000000'),
  
  -- Rabat Addresses
  (NEWID(), @RabatId, 'Hay Riad', '10000', '456 Boulevard Hay Riad', GETDATE(), GETDATE(), '00000000-0000-0000-0000-000000000000'),
  (NEWID(), @RabatId, 'Agdal', '10080', '321 Avenue Fal Ould Oumeir', GETDATE(), GETDATE(), '00000000-0000-0000-0000-000000000000'),
  (NEWID(), @RabatId, 'Hassan', '10100', '654 Rue Hassan', GETDATE(), GETDATE(), '00000000-0000-0000-0000-000000000000');
