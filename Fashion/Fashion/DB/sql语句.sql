
--指定对某一个数据库进行操作
USE [Fashion]


--设置自增字段需要先删除再添加
alter table [user] drop column userid
alter table [user] add userId int identity(1,1)  not null




--删除约束
alter table [user] drop constraint pk_user
alter table [user] drop constraint ck_user
--设置主键
alter table [user] add constraint PKUser_userId   primary key(userid)
alter table [user] drop constraint PKUser_userId
--新建约束
alter table [user] add constraint ck_user_sex check (sex='男' or sex='女')
alter table [user] drop constraint ck_user
--设置默认值
alter table [user] add constraint DFUser_starcount default 0 for starcount
alter table [user] drop constraint DFUser_starcount

alter table [user] alter column userName nvarchar(25) not null





--设置user表的约束：包括 主键PK 唯一UQ 默认DF 检查CK 外键FK
alter table [user] add constraint PKUser_userId primary key(userId)
alter table [user] add constraint CKUser_sex check (sex='男' or sex='女')
alter table [user] add constraint UQUser_userName unique (username)
alter table [user] add constraint CKUser_rank check([rank]>0 and [rank]<5)

alter table [user] add constraint CKUser_isMessageRemind check (isMessageRemind=1 or isMessageRemind=0)
alter table [user] add constraint DFUser_isMessageRemind default 1 for isMessageRemind

--等级表Rank
create table [Rank]
(
rankId char(1)  not null,
rankName nchar(4) not null,
constraint PKRank_rankId primary key(rankId)
)
alter table [rank] add constraint UQRank_rankName unique (rankname)
--drop table [rank]
insert into [rank] values(1,'普通用户')
insert into [rank] values(2,'时尚达人')
insert into [rank] values(3,'专家')
Insert into [rank] values(4,'管理员')


--消息表Message
create table [Message]
(
messageId int not null identity(1,1),
content nvarchar(200) null,
msgSender nvarchar(25) not null,
msgReceiver nvarchar(25) not null,
msgDate datetime,
constraint PKMessage_messageId primary key(messageId)
)

--帖子信息表Post
create table [Post]
(
postId int not null identity(1,1),
caption nvarchar(40) not null,
content text null,
postSender nvarchar(25) not null,
postTypeId int not null,
theme int not null,
supportCount int null,
postDate datetime,
constraint PKPost_postId primary key(postId)
)
alter table [post] add constraint DFPost_supportCount default 0 for supportCount

--板块类型表Theme
create table[Theme]
(
themeId int not null,
themeName nvarchar(5) not null,
constraint PKTheme_themeId primary key(themeId),
constraint UQTheme_themeId unique (themeId)
)
insert into theme values(1,'服装')
insert into theme values(2,'饰品')

--模块类型表Module
create table [Module]
(
moduleId int not null,
moduleName nvarchar(5) not null,
constraint PKModule_Id primary key(moduleId),
constraint UQModule_moduleName unique (moduleName)
)
insert into [Module] values(1,'问题咨询')
insert into [Module] values(2,'日志')
insert into [Module] values(3,'街拍')
insert into [Module] values(4,'视频')
insert into [Module] values(5,'个人秀照片')

--帖子类型表PostType
create table [PostType]
(
postTypeId int not null,
postTypeName nvarchar(5) not null,
constraint PKPostType_Id primary key(postTypeId),
constraint UQPostType_postTypeName unique (postTypeName)
)
insert into [PostType] values(1,'问题咨询')
insert into [PostType] values(2,'日志')
insert into [PostType] values(3,'街拍')
insert into [PostType] values(4,'视频')
insert into [PostType] values(5,'个人秀照片')

--街拍信息表StreetSnap
create table StreetSnap
(
streetSnapId int not null identity(1,1),
streetSnapTypeId int not null,
postId int null,
constraint PKStreetSnap_streetSnapId primary key(streetSnapId),
)

drop table StreetSnap
--街拍类型表StreetSnapType
create table StreetSnapType
(
streetSnapTypeId int not null,
streetSnapType nvarchar(8) not null,
constraint PKStreetSnapType_Id primary key(streetSnapTypeId),
constraint UQStreetSnapType_streetSnapType unique(streetSnapType)
)

insert into StreetSnapType values(1,'个人街拍')

--视频秀信息表VideoShow
create table VideoShow
(
videoShowId int not null identity(1,1),
postId int not null,
constraint PKVideoShow_videoShowId primary key(videoShowId),
)

--收藏记录Collect
create table Collect
(
collectId int not null identity (1,1),
collector nvarchar(25) not null,
postId int not null,
constraint PKCollect_collectId primary key(collectId)
)


--关注记录表Attention
create table Attention
(
attentionId int not null identity(1,1),
concerns nvarchar(25) not null,
beConcerned nvarchar(25) not null,
constraint PKAttention_attentionId primary key(attentionId)
)

--回帖表ReplyPost
create table ReplyPost
(
replyPostId int not null identity(1,1),
postId int not null,
replyer nvarchar(25) not null,
content text,
constraint PKReplyPost_replyPostId primary key(replyPostId)
)

--评论表Comment
create table Comment
(
commentId int not null identity(1,1),
postId int not null,
conmenter nvarchar(25) not null,
becomment nvarchar(25) not null,
content text,
constraint PKComment_commentId primary key(commentId)
)
