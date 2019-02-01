--create database BlogCore
--on
--(
--	name='BlogCore',
--	filename='E:\个人项目存放处2019\hunzi.Web\数据库\BlogCore.mdf'
--)
use BlogCore

create table Admin --管理员表
(
	Aid int primary key identity ,                      --主键ID
	CreateDate datetime default(getdate()) not null,	--创建时间
	UserName varchar(64) not null,						--管理员账户
	[PassWord] varchar(64) not null,					--密码
	Remark varchar(200) not null						--备注
)
go
create table Category --分类表
(
	 Cid int primary key identity,						--主键ID
	 CreateDate datetime default(getdate()) not null,	--创建时间
	 CaName varchar(50),								--分类名称
	 Bh nvarchar(64),									--分类编号
	 Pbh nvarchar(64),									--父级编号
	 Remark nvarchar(200)								--备注
)
go
create table Blog --博客表
(
	Bid int primary key identity,						--主键ID
	CreateDate datetime default(getdate()) not null,	--创建时间
	Title varchar(150) not null,						--标题
	Body ntext not null,								--内容
	Body_md ntext,										--内容-Markdown
	ViewNum int not null  default(0),					--访问量
	CaBh nvarchar(64),									--分类编号
	CaName varchar(50),									--分类名称
	Remark  varchar(200),								--备注
	Sort int default(0)									--排序
)
go
insert into Admin(UserName,PassWord) values('admin',HASHBYTES('md5','123456'))
select * from Admin
go
alter table Admin alter Column [PassWord] varchar(248)

update Admin set [PassWord]='0xE10ADC3949BA59ABBE56E057F20F883E'

select HASHBYTES('md5','123456')
