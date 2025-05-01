IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [Order_Date] datetime2 NOT NULL,
    [CustomerId] int NOT NULL,
    [CustomerName] varchar(50) NOT NULL,
    [PaymentMethodId] int NOT NULL,
    [PaymentMethodName] varchar(30) NOT NULL,
    [ShippingMethodAddress] varchar(100) NOT NULL,
    [ShippingMethod] varchar(50) NOT NULL,
    [BillAmount] decimal(5,2) NOT NULL,
    [Order_Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id])
);

CREATE TABLE [Order_Details] (
    [Id] int NOT NULL IDENTITY,
    [Product_Id] int NOT NULL,
    [Product_name] varchar(40) NOT NULL,
    [Quantity] int NOT NULL,
    [Price] decimal(5,2) NOT NULL,
    [Discount] decimal(5,2) NOT NULL,
    [OrderId] int NOT NULL,
    CONSTRAINT [PK_Order_Details] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Order_Details_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Order_Details_OrderId] ON [Order_Details] ([OrderId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250501195848_InitialMigration', N'9.0.4');

COMMIT;
GO

