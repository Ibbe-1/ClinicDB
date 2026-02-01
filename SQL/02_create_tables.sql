-- Recipes
CREATE TABLE dbo.Recipes (
    RecipeId INT IDENTITY(1,1) CONSTRAINT PK_Recipes PRIMARY KEY,
    Title NVARCHAR(120) NOT NULL,
    PrepMinutes INT NOT NULL CONSTRAINT CK_Recipes_Prep CHECK (PrepMinutes >= 0),
    CookMinutes INT NOT NULL CONSTRAINT CK_Recipes_Cook CHECK (CookMinutes >= 0),
    Servings INT NOT NULL CONSTRAINT CK_Recipes_Servings CHECK (Servings > 0),
    CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Recipes_CreatedAt DEFAULT (SYSDATETIME())
);

-- Ingredients
CREATE TABLE dbo.Ingredients (
    IngredientId INT IDENTITY(1,1) CONSTRAINT PK_Ingredients PRIMARY KEY,
    Name NVARCHAR(120) NOT NULL,
    CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Ingredients_CreatedAt DEFAULT (SYSDATETIME())
);

-- M:N (koppling)
CREATE TABLE dbo.RecipeIngredients (
    RecipeId INT NOT NULL,
    IngredientId INT NOT NULL,
    Quantity DECIMAL(10,2) NOT NULL CONSTRAINT CK_RecipeIngredients_Qty CHECK (Quantity > 0),
    Unit NVARCHAR(20) NOT NULL,
    CONSTRAINT PK_RecipeIngredients PRIMARY KEY (RecipeId, IngredientId),
    CONSTRAINT FK_RecipeIngredients_Recipes FOREIGN KEY (RecipeId) REFERENCES dbo.Recipes(RecipeId),
    CONSTRAINT FK_RecipeIngredients_Ingredients FOREIGN KEY (IngredientId) REFERENCES dbo.Ingredients(IngredientId)
);

CREATE TABLE dbo.RecipeRatings (
    RatingId INT IDENTITY(1,1) CONSTRAINT PK_RecipeRatings PRIMARY KEY,
    RecipeId INT NOT NULL,
    Grade CHAR(2) NOT NULL CONSTRAINT CK_RecipeRatings_Grade CHECK (Grade IN ('IG','G')),
    Comment NVARCHAR(300) NULL,
    CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_RecipeRatings_CreatedAt DEFAULT (SYSDATETIME()),
    CONSTRAINT FK_RecipeRatings_Recipes FOREIGN KEY (RecipeId) REFERENCES dbo.Recipes(RecipeId)
);

USE ClinicDB;
GO

USE ClinicDB;
GO

CREATE TABLE dbo.Prescriptions (
    PrescriptionId INT IDENTITY(1,1)
        CONSTRAINT PK_Prescriptions PRIMARY KEY,

    PersonalId INT NOT NULL,   -- läkaren/sjuksköterskan

    IssuedAt DATETIME2 NOT NULL
        CONSTRAINT DF_Prescriptions_IssuedAt DEFAULT (SYSDATETIME()),

    ValidUntil DATE NULL,

    Status NVARCHAR(20) NOT NULL
        CONSTRAINT CK_Prescriptions_Status 
        CHECK (Status IN ('Active','Cancelled','Expired')),

    Notes NVARCHAR(300) NULL
);

