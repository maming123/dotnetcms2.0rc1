if exists (select * from sysobjects where id = object_id(N'[fs_api_navi]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table [fs_api_navi];
if exists (select * from sysobjects where id = object_id(N'[fs_classdroptemplet]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table fs_classdroptemplet;
if exists (select * from sysobjects where id = object_id(N'[fs_newsdroptemplet]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table fs_newsdroptemplet;
if exists (select * from sysobjects where id = object_id(N'[fs_specialdroptemplet]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table fs_specialdroptemplet;
if exists (select * from sysobjects where id = object_id(N'[fs_Attachments]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
drop table fs_Attachments;

CREATE TABLE [fs_api_navi] (
	[am_ID] [int] IDENTITY (1, 1) NOT NULL ,
	[am_ClassID] [nvarchar] (12) COLLATE Chinese_PRC_CI_AS NULL ,
	[am_Name] [nvarchar] (20) COLLATE Chinese_PRC_CI_AS NULL ,
	[am_FilePath] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[am_ChildrenID] [ntext] COLLATE Chinese_PRC_CI_AS NULL ,
	[am_creatTime] [datetime] NULL ,
	[am_orderID] [int] NULL ,
	[isSys] [tinyint] NULL ,
	[siteID] [nvarchar] (12) COLLATE Chinese_PRC_CI_AS NULL ,
	[userNum] [nvarchar] (15) COLLATE Chinese_PRC_CI_AS NULL ,
	[popCode] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[imgPath] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL ,
	[imgwidth] [nvarchar] (10) COLLATE Chinese_PRC_CI_AS NULL ,
	[imgheight] [nvarchar] (10) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
;
CREATE TABLE [fs_classdroptemplet] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[ClassId] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Templet] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL ,
	[ReadNewsTemplet] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
;
CREATE TABLE [fs_newsdroptemplet] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[NewsId] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Templet] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
;
CREATE TABLE [fs_specialdroptemplet] (
	[Id] [int] IDENTITY (1, 1) NOT NULL ,
	[SpecialId] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL ,
	[Templet] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL 
) ON [PRIMARY]
;
CREATE TABLE [dbo].[fs_Attachments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](50) NULL,
	[FileType] [varchar](50) NULL,
	[UploadDate] [datetime] NULL,
	[FileSize] [varchar](50) NULL,
	[FilePath] [varchar](200) NULL,
) ON [PRIMARY]
ALTER table fs_sys_param add publishType int default 0;