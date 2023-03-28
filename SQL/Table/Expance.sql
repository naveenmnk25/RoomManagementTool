If(Object_Id('Expance') Is Not Null)
Begin
	Drop Table [Expance]
End
GO

Create Table DBO.[Expance]
(
	 Id					Int  Identity(1, 1)	Not Null
	,[Item]				Nvarchar(100)		
	,MemberId			Int		
	,Price				Int
	,[Date]				DateTime		
	,CreatedBy			Int
	,CreatedDate		DateTime
	,ModifiedDate		DateTime
	,ModifiedBy			Int
)
GO

Alter Table dbo.Expance
Add Constraint PK_Expance Primary Key (Id)

Alter Table dbo.Expance
Add Constraint DF_Expance_CreatedDate
Default GetDate() FOR CreatedDate
Go

Alter Table dbo.Expance
Add Constraint DF_Expance_ModifiedDate
Default GetDate() FOR ModifiedDate
Go
