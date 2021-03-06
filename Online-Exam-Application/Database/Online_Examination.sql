USE [master]
GO
/****** Object:  Database [Online_Examination]    Script Date: 1/3/2022 7:28:02 PM ******/
CREATE DATABASE [Online_Examination]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Online_Examination', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Online_Examination.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Online_Examination_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Online_Examination_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Online_Examination] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Online_Examination].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Online_Examination] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Online_Examination] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Online_Examination] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Online_Examination] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Online_Examination] SET ARITHABORT OFF 
GO
ALTER DATABASE [Online_Examination] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Online_Examination] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Online_Examination] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Online_Examination] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Online_Examination] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Online_Examination] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Online_Examination] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Online_Examination] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Online_Examination] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Online_Examination] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Online_Examination] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Online_Examination] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Online_Examination] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Online_Examination] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Online_Examination] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Online_Examination] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Online_Examination] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Online_Examination] SET RECOVERY FULL 
GO
ALTER DATABASE [Online_Examination] SET  MULTI_USER 
GO
ALTER DATABASE [Online_Examination] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Online_Examination] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Online_Examination] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Online_Examination] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Online_Examination] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Online_Examination] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Online_Examination', N'ON'
GO
ALTER DATABASE [Online_Examination] SET QUERY_STORE = OFF
GO
USE [Online_Examination]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[course_id] [int] IDENTITY(1,1) NOT NULL,
	[course_title] [varchar](200) NULL,
PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[course_id] [int] NULL,
	[question_name] [varchar](255) NULL,
	[Ans1] [varchar](255) NULL,
	[Ans2] [varchar](255) NULL,
	[Ans3] [varchar](255) NULL,
	[Ans4] [varchar](255) NULL,
	[correct_ans] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Results]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Results](
	[result_id] [int] IDENTITY(1,1) NOT NULL,
	[student_id] [int] NULL,
	[course_id] [int] NULL,
	[grade] [varchar](50) NOT NULL,
	[quality] [varchar](50) NOT NULL,
	[correct_ans] [int] NULL,
	[total_questions] [int] NULL,
	[time_of_exam] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[result_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[rolename] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[userrolemapping]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[userrolemapping](
	[mapping_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[role_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mapping_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](200) NOT NULL,
	[password] [varchar](200) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Questions]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([course_id])
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD FOREIGN KEY([course_id])
REFERENCES [dbo].[Course] ([course_id])
GO
ALTER TABLE [dbo].[Results]  WITH CHECK ADD FOREIGN KEY([student_id])
REFERENCES [dbo].[Users] ([user_id])
GO
ALTER TABLE [dbo].[userrolemapping]  WITH CHECK ADD FOREIGN KEY([role_id])
REFERENCES [dbo].[Roles] ([role_id])
GO
ALTER TABLE [dbo].[userrolemapping]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([user_id])
GO
/****** Object:  StoredProcedure [dbo].[getQuestionsofCourse]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getQuestionsofCourse]
@course_title varchar(200)
As
Begin

 select * from Questions where course_id in (select course_id from Course where course_title=@course_title);

End
GO
/****** Object:  StoredProcedure [dbo].[sp_checkValidUser]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_checkValidUser]
@username varchar(200),
@password varchar(200)
As
Begin 
	select * from users where username =@username and password = @password;
End
GO
/****** Object:  StoredProcedure [dbo].[sp_getCourses]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_getCourses]
As
Begin
	Select * from Course;
End
GO
/****** Object:  StoredProcedure [dbo].[sp_getresults]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_getresults]
As
Begin
select Users.username as student_Name, Course.course_title , grade, 
quality , correct_ans , total_questions, time_of_exam from  Results join Users on Results.student_id = Users.user_id
join Course on Results.course_id = Course.course_id;
End
GO
/****** Object:  StoredProcedure [dbo].[SP_getTotalQuestionsPerCourse]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_getTotalQuestionsPerCourse]
As
Begin
	select course_title, count(Questions.id) As Total_Questions from Course left join Questions on 
	Course.course_id=Questions.course_id
	group by Course.course_title order by course_title desc;
End
GO
/****** Object:  StoredProcedure [dbo].[sp_getUserRoles]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_getUserRoles]
@username varchar(200)
As
Begin 
	select rolename from roles join userrolemapping on roles.role_id = userrolemapping.role_id
	where userrolemapping.user_id in (select user_id from Users where username = @username);
end
GO
/****** Object:  StoredProcedure [dbo].[SP_insertQuestion]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_insertQuestion]
@course_id int, @question_title varchar(255), @ans1 varchar(255), @ans2 varchar(255), 
@ans3 varchar(255), @ans4 varchar(255), 
@correct_ans varchar(255)
As 
Begin
	insert into Questions values(@course_id,@question_title,@ans1,@ans2,@ans3,@ans4,@correct_ans);
End;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertresult]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_insertresult]
@student_id int, @course_id int, @grade varchar(50), @quality varchar(50), @correct_ans int, @total int, @time datetime
As 
Begin
	insert into Results values(@student_id,@course_id,@grade,@quality,@correct_ans,@total,@time);
End;
GO
/****** Object:  StoredProcedure [dbo].[sp_insertresult1]    Script Date: 1/3/2022 7:28:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_insertresult1]
@student_name varchar(200), @course_title varchar(200), @grade varchar(50), @quality varchar(50), @correct_ans int, @total int, @time datetime
As 
Begin
	Declare @course_id int, @student_id int;
	select @student_id = user_id from Users where username = @student_name;
	select @course_id = course_id from Course where course_title = @course_title;
	insert into Results values(@student_id,@course_id,@grade,@quality,@correct_ans,@total,@time);
End;
GO
USE [master]
GO
ALTER DATABASE [Online_Examination] SET  READ_WRITE 
GO
