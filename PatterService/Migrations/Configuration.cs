namespace PatterService.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PatterService.Models.PatterServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PatterServiceContext context)
        {
            #region Admin Seed
            context.Admins.AddOrUpdate(x => x.AdminNo,
                new Admin() { AdminNo = 17, WriteId = "Jasper.Teis@gamil.com", Password = "124", WriteName = @"홍길동", DateCreated = DateTime.Now },
                new Admin() { AdminNo = 18, WriteId = "ABC@gamil.com", Password = "123", WriteName = @"이순신", DateCreated = DateTime.Now },
                new Admin() { AdminNo = 19, WriteId = "BBB@gamil.com", Password = "456", WriteName = @"유성룡", DateCreated = DateTime.Now }
            );
            #endregion Admin Seed

            #region Member Seed
            context.Members.AddOrUpdate(x => x.MemberNo,
                new Member() { MemberNo = 17, MemberName = "홍길동", ProfilePicture = "홍길동.jpg", Email = "Japer.teis@gmail.com", DateCreated = DateTime.Now },
                new Member() { MemberNo = 18, MemberName = "이순신", ProfilePicture = "이순신.jpg", Email = "Japer.teis@gmail.com", DateCreated = DateTime.Now },
                new Member() { MemberNo = 19, MemberName = "권율", ProfilePicture = "권율.jpg", Email = "Japer.teis@gmail.com", DateCreated = DateTime.Now }

            );
            #endregion Member Seed

            #region Company Seed
            context.Companies.AddOrUpdate(x => x.CompanyNo,
                new Company() { CompanyNo = 17, CompanyName = "강아지 대통령", CompanyAddr = "서울 송파구 장지동", StartShopHours = "0930", EndShopHours = "1830", Holiday = "토요일", Introduction = "개사료 판매합니다.", Geo = DbGeography.FromText("POINT(126.9784 37.5667)") },
                new Company() { CompanyNo = 18, CompanyName = "고양이 대통령", CompanyAddr = "서울 구로구 구로동", StartShopHours = "0630", EndShopHours = "1800", Holiday = "토요일", Introduction = "고양이 사료 판매합니다.", Geo = DbGeography.FromText("POINT(126.9784 37.5667)") },
                new Company() { CompanyNo = 19, CompanyName = "돼지 대통령", CompanyAddr = "서울 노원구 사계동", StartShopHours = "0730", EndShopHours = "1930", Holiday = "토요일", Introduction = "돼지료 판매합니다.", Geo = DbGeography.FromText("POINT(126.9784 37.5667)") }

            );
            #endregion Company Seed

            #region Event Seed
            context.Events.AddOrUpdate(x => x.EventNo,
                new Models.Event() { EventNo = 4, WriteId = "ABC@gamil.com", Title = "이벤트1", Content = "이벤트 내용1"},
                new Models.Event() { EventNo = 5, WriteId = "ABC@gamil.com", Title = "이벤트2", Content = "이벤트 내용2"},
                new Models.Event() { EventNo = 6, WriteId = "ABC@gamil.com", Title = "이벤트3", Content = "이벤트 내용3"}

            );
            #endregion Event Seed

            #region Notification Seed
            context.Notifications.AddOrUpdate(x => x.NotificationNo,
                new Models.Notification { NotificationNo = 1, WriteId = "ABC@gamil.com", Title = "공지1", Content = "공지내용1", PictureName = "abc.jpg", PicturePath = "/images/notification/" },
                new Models.Notification { NotificationNo = 2, WriteId = "ABC@gamil.com", Title = "공지2", Content = "공지내용2", PictureName = "abc.jpg", PicturePath = "/images/notification/" },
                new Models.Notification { NotificationNo = 3, WriteId = "ABC@gamil.com", Title = "공지3", Content = "공지내용3", PictureName = "abc.jpg", PicturePath = "/images/notification/" }
            );
            #endregion Notification Seed
        }
    }
}
