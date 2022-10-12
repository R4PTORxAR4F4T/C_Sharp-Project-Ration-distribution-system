CREATE TABLE [dbo].[RegisteredData] (
    [UserType]        VARCHAR (10) NOT NULL,
    [FullName]        VARCHAR (25) NOT NULL,
    [Password]         VARCHAR (50) NOT NULL,
    [ConfirmPassword] VARCHAR (50) NOT NULL,
    [Gender]           CHAR (10)    NOT NULL,
    [Age]              INT          NOT NULL,
    [Number]           INT          NOT NULL,
    [Address]          VARCHAR (50) NOT NULL,
    [NIDNumber]       INT          NOT NULL,
    [Ration ID]        INT          NOT NULL,
    [History]          VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Registered Data] PRIMARY KEY CLUSTERED ([Ration ID] ASC)
);

