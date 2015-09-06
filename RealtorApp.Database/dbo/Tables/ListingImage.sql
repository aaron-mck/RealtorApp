CREATE TABLE [dbo].[ListingImage] (
    [ListingImageID] INT           IDENTITY (1, 1) NOT NULL,
    [ListingID]      INT           NOT NULL,
    [ImageName]      NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_ListingImage] PRIMARY KEY CLUSTERED ([ListingImageID] ASC),
    CONSTRAINT [FK_ListingImage_Home] FOREIGN KEY ([ListingID]) REFERENCES [dbo].[Listing] ([ListingID]) ON DELETE CASCADE
);







GO

GRANT SELECT
    ON OBJECT::[dbo].[ListingImage] TO [RealtorAppMLSUser]
    AS [dbo];


GO
GRANT INSERT
    ON OBJECT::[dbo].[ListingImage] TO [RealtorAppMLSUser]
    AS [dbo];


GO
GRANT DELETE
    ON OBJECT::[dbo].[ListingImage] TO [RealtorAppMLSUser]
    AS [dbo];


GO
GRANT UPDATE
    ON OBJECT::[dbo].[ListingImage] TO [RealtorAppMLSUser]
    AS [dbo];


GO
