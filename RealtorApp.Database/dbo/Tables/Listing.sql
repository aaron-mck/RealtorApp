CREATE TABLE [dbo].[Listing] (
    [MLS]          INT            NOT NULL,
    [Street1]      NVARCHAR (50)  NOT NULL,
    [Street2]      NVARCHAR (50)  NULL,
    [City]         NVARCHAR (50)  NOT NULL,
    [State]        NVARCHAR (50)  NOT NULL,
    [Zipcode]      INT            NOT NULL,
    [Neighborhood] NVARCHAR (50)  NULL,
    [SalesPrice]   MONEY          NOT NULL,
    [DateListed]   DATE           NOT NULL,
    [Bedrooms]     INT            NOT NULL,
    [Bathrooms]    FLOAT (53)     NOT NULL,
    [GarageSize]   FLOAT (53)     NULL,
    [SquareFeet]   INT            NOT NULL,
    [LotSize]      NVARCHAR (50)  NULL,
    [Description]  NVARCHAR (MAX) NOT NULL,
    [ListingID]    INT            IDENTITY (1, 1) NOT NULL,
    CONSTRAINT [PK_Home] PRIMARY KEY CLUSTERED ([ListingID] ASC)
);



GO

GRANT SELECT
    ON OBJECT::[dbo].[Listing] TO [RealtorAppMLSUser]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[Listing] TO [RealtorAppMLSUser]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[Listing] TO [RealtorAppMLSUser]
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[Listing] TO [RealtorAppMLSUser]
    AS [dbo];


GO