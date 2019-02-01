--create database BlogCore
--on
--(
--	name='BlogCore',
--	filename='E:\������Ŀ��Ŵ�2019\hunzi.Web\���ݿ�\BlogCore.mdf'
--)
use BlogCore

create table Admin --����Ա��
(
	Aid int primary key identity ,                      --����ID
	CreateDate datetime default(getdate()) not null,	--����ʱ��
	UserName varchar(64) not null,						--����Ա�˻�
	[PassWord] varchar(64) not null,					--����
	Remark varchar(200) not null						--��ע
)
go
create table Category --�����
(
	 Cid int primary key identity,						--����ID
	 CreateDate datetime default(getdate()) not null,	--����ʱ��
	 CaName varchar(50),								--��������
	 Bh nvarchar(64),									--������
	 Pbh nvarchar(64),									--�������
	 Remark nvarchar(200)								--��ע
)
go
create table Blog --���ͱ�
(
	Bid int primary key identity,						--����ID
	CreateDate datetime default(getdate()) not null,	--����ʱ��
	Title varchar(150) not null,						--����
	Body ntext not null,								--����
	Body_md ntext,										--����-Markdown
	ViewNum int not null  default(0),					--������
	CaBh nvarchar(64),									--������
	CaName varchar(50),									--��������
	Remark  varchar(200),								--��ע
	Sort int default(0)									--����
)
go
insert into Admin(UserName,PassWord) values('admin',HASHBYTES('md5','123456'))
select * from Admin
go
alter table Admin alter Column [PassWord] varchar(248)

update Admin set [PassWord]='0xE10ADC3949BA59ABBE56E057F20F883E'

select HASHBYTES('md5','123456')
