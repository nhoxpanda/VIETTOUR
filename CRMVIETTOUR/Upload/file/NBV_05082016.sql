USE [Web_NgocBaoVien]
GO
/****** Object:  User [WebNgocBaoVien_login]    Script Date: 5/27/2016 9:02:26 PM ******/
CREATE USER [WebNgocBaoVien_login] FOR LOGIN [WebNgocBaoVien_login] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [WebNgocBaoVien_login]
GO
/****** Object:  Table [dbo].[tbl_CongTrinh]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_CongTrinh](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[HinhDaiDien] [nvarchar](max) NULL,
	[NgayNhap] [datetime] NULL,
 CONSTRAINT [PK_tbl_CongTrinh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DangKyThongTin]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DangKyThongTin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[DiDong] [nvarchar](max) NULL,
	[NhuCau] [nvarchar](max) NULL,
	[NgayDangKy] [datetime] NULL,
	[NgayNhap] [datetime] NULL,
	[GhiChu] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_DangKyThongTin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DanhMuc]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DanhMuc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NULL,
	[Note] [nvarchar](max) NULL,
	[ParentId] [int] NULL,
	[Type] [int] NULL,
	[UrlSlug] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DanhMucHinh]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DanhMucHinh](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_DanhMucHinh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_DuAn]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DuAn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[UrlSlug] [nvarchar](max) NULL,
	[MetaTitle] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
	[HinhDaiDien] [nvarchar](max) NULL,
	[TongQuan] [nvarchar](max) NULL,
	[ChiTiet] [nvarchar](max) NULL,
	[ViTri] [nvarchar](max) NULL,
	[DichVu] [nvarchar](max) NULL,
	[NgayNhap] [datetime] NULL,
 CONSTRAINT [PK_tbl_DuAn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_HinhAnh]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_HinhAnh](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NULL,
	[HinhAnh] [nvarchar](max) NULL,
	[DanhMucHinhId] [int] NULL,
 CONSTRAINT [PK_tbl_HinhAnh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_LienHe]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_LienHe](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HoTen] [nvarchar](200) NULL,
	[DienThoai] [nvarchar](200) NULL,
	[Email] [nvarchar](200) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[NgayDang] [datetime] NULL,
 CONSTRAINT [PK_tbl_LienHe] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TienDo]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TienDo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Thang] [int] NULL,
	[Nam] [int] NULL,
	[TieuDe] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[FileName] [nvarchar](max) NULL,
	[DuAnId] [int] NOT NULL,
	[HinhAnh] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_TienDo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_TinTuc]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TinTuc](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TieuDe] [nvarchar](max) NULL,
	[MoTa] [nvarchar](max) NULL,
	[NoiDung] [nvarchar](max) NULL,
	[HinhDaiDien] [nvarchar](max) NULL,
	[NgayNhap] [datetime] NULL,
	[UrlSlug] [nvarchar](max) NULL,
	[DanhMucId] [int] NULL,
	[MetaTitle] [nvarchar](max) NULL,
	[MetaDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_tbl_TinTuc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 5/27/2016 9:02:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_DanhMuc] ON 

INSERT [dbo].[tbl_DanhMuc] ([Id], [Name], [Note], [ParentId], [Type], [UrlSlug]) VALUES (1, N'Chủ đầu tư', NULL, 0, 1, N'chu-dau-tu')
INSERT [dbo].[tbl_DanhMuc] ([Id], [Name], [Note], [ParentId], [Type], [UrlSlug]) VALUES (2, N'Tổng quan dự án', NULL, 0, 1, N'tong-quan-du-an')
INSERT [dbo].[tbl_DanhMuc] ([Id], [Name], [Note], [ParentId], [Type], [UrlSlug]) VALUES (3, N'Tin tức', NULL, 0, 1, N'tin-tuc')
INSERT [dbo].[tbl_DanhMuc] ([Id], [Name], [Note], [ParentId], [Type], [UrlSlug]) VALUES (4, N'Thư viện ảnh', NULL, 0, 1, N'thu-vien-anh')
INSERT [dbo].[tbl_DanhMuc] ([Id], [Name], [Note], [ParentId], [Type], [UrlSlug]) VALUES (5, N'Thông tin nội bộ', NULL, 0, 1, N'thong-tin-noi-bo')
INSERT [dbo].[tbl_DanhMuc] ([Id], [Name], [Note], [ParentId], [Type], [UrlSlug]) VALUES (6, N'Liên hệ', NULL, 0, 1, N'lien-he')
INSERT [dbo].[tbl_DanhMuc] ([Id], [Name], [Note], [ParentId], [Type], [UrlSlug]) VALUES (8, N'Sản phẩm', NULL, 2, 1, N'san-pham')
SET IDENTITY_INSERT [dbo].[tbl_DanhMuc] OFF
SET IDENTITY_INSERT [dbo].[tbl_DanhMucHinh] ON 

INSERT [dbo].[tbl_DanhMucHinh] ([Id], [TieuDe]) VALUES (1, N'Phối cảnh công trình')
INSERT [dbo].[tbl_DanhMucHinh] ([Id], [TieuDe]) VALUES (2, N'Lối vào')
INSERT [dbo].[tbl_DanhMucHinh] ([Id], [TieuDe]) VALUES (3, N'Sảnh chính')
INSERT [dbo].[tbl_DanhMucHinh] ([Id], [TieuDe]) VALUES (4, N'Sảnh thang máy')
INSERT [dbo].[tbl_DanhMucHinh] ([Id], [TieuDe]) VALUES (5, N'Mặt bằng tầng điển hình')
INSERT [dbo].[tbl_DanhMucHinh] ([Id], [TieuDe]) VALUES (6, N'Khu vệ sinh')
SET IDENTITY_INSERT [dbo].[tbl_DanhMucHinh] OFF
SET IDENTITY_INSERT [dbo].[tbl_DuAn] ON 

INSERT [dbo].[tbl_DuAn] ([Id], [TieuDe], [MoTa], [UrlSlug], [MetaTitle], [MetaDescription], [HinhDaiDien], [TongQuan], [ChiTiet], [ViTri], [DichVu], [NgayNhap]) VALUES (1, N'Khu biệt thự Osaka', NULL, N'biet-thu-osaka', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_DuAn] ([Id], [TieuDe], [MoTa], [UrlSlug], [MetaTitle], [MetaDescription], [HinhDaiDien], [TongQuan], [ChiTiet], [ViTri], [DichVu], [NgayNhap]) VALUES (2, N'Khu nhà phố kinh doanh', NULL, N'nha-pho-kinh-doanh', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_DuAn] ([Id], [TieuDe], [MoTa], [UrlSlug], [MetaTitle], [MetaDescription], [HinhDaiDien], [TongQuan], [ChiTiet], [ViTri], [DichVu], [NgayNhap]) VALUES (3, N'Khu biệt thự song lập', NULL, N'biet-thu-song-lap', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_DuAn] ([Id], [TieuDe], [MoTa], [UrlSlug], [MetaTitle], [MetaDescription], [HinhDaiDien], [TongQuan], [ChiTiet], [ViTri], [DichVu], [NgayNhap]) VALUES (4, N'Khu nhà phố liền kề', NULL, N'nha-pho-lien-ke', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_DuAn] OFF
SET IDENTITY_INSERT [dbo].[tbl_TienDo] ON 

INSERT [dbo].[tbl_TienDo] ([Id], [Thang], [Nam], [TieuDe], [NoiDung], [FileName], [DuAnId], [HinhAnh]) VALUES (1, 1, 2014, NULL, NULL, N'', 1, NULL)
SET IDENTITY_INSERT [dbo].[tbl_TienDo] OFF
SET IDENTITY_INSERT [dbo].[tbl_TinTuc] ON 

INSERT [dbo].[tbl_TinTuc] ([Id], [TieuDe], [MoTa], [NoiDung], [HinhDaiDien], [NgayNhap], [UrlSlug], [DanhMucId], [MetaTitle], [MetaDescription]) VALUES (1, N'Giới thiệu', N'Giới thiệu', N'Giới thiệu', NULL, CAST(0x0000A60F00000000 AS DateTime), N'gioi-thieu', 1, NULL, NULL)
INSERT [dbo].[tbl_TinTuc] ([Id], [TieuDe], [MoTa], [NoiDung], [HinhDaiDien], [NgayNhap], [UrlSlug], [DanhMucId], [MetaTitle], [MetaDescription]) VALUES (2, N'Đối tác thực hiện dự án', N'Đối tác thực hiện dự án', N'Đối tác thực hiện dự án', NULL, CAST(0x0000A60F00000000 AS DateTime), N'doi-tac-thuc-hien-du-an', 1, NULL, NULL)
INSERT [dbo].[tbl_TinTuc] ([Id], [TieuDe], [MoTa], [NoiDung], [HinhDaiDien], [NgayNhap], [UrlSlug], [DanhMucId], [MetaTitle], [MetaDescription]) VALUES (3, N'Vị trí', N'Vị trí', N'Vị trí', NULL, CAST(0x0000A60F00000000 AS DateTime), N'vi-tri', 2, NULL, NULL)
INSERT [dbo].[tbl_TinTuc] ([Id], [TieuDe], [MoTa], [NoiDung], [HinhDaiDien], [NgayNhap], [UrlSlug], [DanhMucId], [MetaTitle], [MetaDescription]) VALUES (4, N'Giai đoạn phát triển', N'Giai đoạn phát triển', N'Giai đoạn phát triển', NULL, CAST(0x0000A60F00000000 AS DateTime), N'giai-doan-phat-trien', 2, NULL, NULL)
INSERT [dbo].[tbl_TinTuc] ([Id], [TieuDe], [MoTa], [NoiDung], [HinhDaiDien], [NgayNhap], [UrlSlug], [DanhMucId], [MetaTitle], [MetaDescription]) VALUES (5, N'Khu biệt thự Osaka', N'Khu biệt thự Osaka', N'Khu biệt thự Osaka', NULL, CAST(0x0000A60F00000000 AS DateTime), N'khu-biet-thu-osaka', 8, NULL, NULL)
INSERT [dbo].[tbl_TinTuc] ([Id], [TieuDe], [MoTa], [NoiDung], [HinhDaiDien], [NgayNhap], [UrlSlug], [DanhMucId], [MetaTitle], [MetaDescription]) VALUES (6, N'Khu nhà phố kinh doanh', N'Khu nhà phố kinh doanh', N'Khu nhà phố kinh doanh', NULL, CAST(0x0000A60F00000000 AS DateTime), N'khu-nha-pho-kinh-doanh', 8, NULL, NULL)
INSERT [dbo].[tbl_TinTuc] ([Id], [TieuDe], [MoTa], [NoiDung], [HinhDaiDien], [NgayNhap], [UrlSlug], [DanhMucId], [MetaTitle], [MetaDescription]) VALUES (7, N'Khu biệt thự song lập', N'Khu biệt thự song lập', N'Khu biệt thự song lập', NULL, CAST(0x0000A60F00000000 AS DateTime), N'khu-biet-thu-song-lap', 8, NULL, NULL)
INSERT [dbo].[tbl_TinTuc] ([Id], [TieuDe], [MoTa], [NoiDung], [HinhDaiDien], [NgayNhap], [UrlSlug], [DanhMucId], [MetaTitle], [MetaDescription]) VALUES (8, N'Khu nhà phố liền kề', N'Khu nhà phố liền kề', N'Khu nhà phố liền kề', NULL, CAST(0x0000A60F00000000 AS DateTime), N'khu-nha-pho-lien-ke', 8, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tbl_TinTuc] OFF
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (1, N'admin')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (1, CAST(0x0000A610004B980B AS DateTime), NULL, 1, NULL, 0, N'ALqr+fUqljC+v0BrFp/9J9gvqui2ux3fAQ1O/4+wQO0OnKofohDyeU0mz9KPqYoSbQ==', CAST(0x0000A610004B980B AS DateTime), N'', NULL, NULL)
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserProf__C9F28456164452B1]    Script Date: 5/27/2016 9:02:27 PM ******/
ALTER TABLE [dbo].[UserProfile] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__webpages__8A2B6160267ABA7A]    Script Date: 5/27/2016 9:02:27 PM ******/
ALTER TABLE [dbo].[webpages_Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[tbl_HinhAnh]  WITH CHECK ADD  CONSTRAINT [FK_tbl_HinhAnh_tbl_HinhAnh] FOREIGN KEY([DanhMucHinhId])
REFERENCES [dbo].[tbl_DanhMucHinh] ([Id])
GO
ALTER TABLE [dbo].[tbl_HinhAnh] CHECK CONSTRAINT [FK_tbl_HinhAnh_tbl_HinhAnh]
GO
ALTER TABLE [dbo].[tbl_TienDo]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TienDo_tbl_DuAn] FOREIGN KEY([DuAnId])
REFERENCES [dbo].[tbl_DuAn] ([Id])
GO
ALTER TABLE [dbo].[tbl_TienDo] CHECK CONSTRAINT [FK_tbl_TienDo_tbl_DuAn]
GO
ALTER TABLE [dbo].[tbl_TinTuc]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TinTuc_tbl_DanhMuc] FOREIGN KEY([DanhMucId])
REFERENCES [dbo].[tbl_DanhMuc] ([Id])
GO
ALTER TABLE [dbo].[tbl_TinTuc] CHECK CONSTRAINT [FK_tbl_TinTuc_tbl_DanhMuc]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
