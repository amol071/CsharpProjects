INSERT INTO tbl_Client (client_id, client_name, client_address, client_city, client_country, client_pincode, IsActive, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy)
VALUES 
    (1, 'Client 1', '123 Main St', 'City 1', 'Country 1', '12345', 1, GETDATE(), 'Admin', GETDATE(), 'Admin'),
    (2, 'Client 2', '456 Elm St', 'City 2', 'Country 2', '23456', 1, GETDATE(), 'Admin', GETDATE(), 'Admin'),
    (3, 'Client 3', '789 Oak St', 'City 3', 'Country 3', '34567', 1, GETDATE(), 'Admin', GETDATE(), 'Admin');
