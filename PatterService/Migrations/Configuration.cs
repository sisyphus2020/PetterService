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
                new Admin() { AdminNo = 17, WriteId = "Jasper.Teis@gamil.com", Password = "124", WriteName = @"ȫ�浿", DateCreated = DateTime.Now },
                new Admin() { AdminNo = 18, WriteId = "ABC@gamil.com", Password = "123", WriteName = @"�̼���", DateCreated = DateTime.Now },
                new Admin() { AdminNo = 19, WriteId = "BBB@gamil.com", Password = "456", WriteName = @"������", DateCreated = DateTime.Now }
            );
            #endregion Admin Seed

            #region Member Seed
            context.Members.AddOrUpdate(x => x.MemberNo,
                new Member() { MemberNo = 17, MemberName = "ȫ�浿", ProfilePicture = "ȫ�浿.jpg", Email = "Japer.teis@gmail.com", DateCreated = DateTime.Now },
                new Member() { MemberNo = 18, MemberName = "�̼���", ProfilePicture = "�̼���.jpg", Email = "Japer.teis@gmail.com", DateCreated = DateTime.Now },
                new Member() { MemberNo = 19, MemberName = "����", ProfilePicture = "����.jpg", Email = "Japer.teis@gmail.com", DateCreated = DateTime.Now }

            );
            #endregion Member Seed

            #region Company Seed
            context.Companies.AddOrUpdate(x => x.CompanyNo,
                new Company() { CompanyNo = 17, CompanyName = "������ �����", CompanyAddr = "���� ���ı� ������", StartShopHours = "0930", EndShopHours = "1830", Holiday = "�����", Introduction = "����� �Ǹ��մϴ�.", Geo = DbGeography.FromText("POINT(126.9784 37.5667)") },
                new Company() { CompanyNo = 18, CompanyName = "����� �����", CompanyAddr = "���� ���α� ���ε�", StartShopHours = "0630", EndShopHours = "1800", Holiday = "�����", Introduction = "����� ��� �Ǹ��մϴ�.", Geo = DbGeography.FromText("POINT(126.9784 37.5667)") },
                new Company() { CompanyNo = 19, CompanyName = "���� �����", CompanyAddr = "���� ����� ��赿", StartShopHours = "0730", EndShopHours = "1930", Holiday = "�����", Introduction = "������ �Ǹ��մϴ�.", Geo = DbGeography.FromText("POINT(126.9784 37.5667)") }

            );
            #endregion Company Seed

            #region Event Seed
            context.Events.AddOrUpdate(x => x.EventNo,
                new Models.Event() { EventNo = 4, WriteId = "ABC@gamil.com", Title = "�̺�Ʈ1", Content = "�̺�Ʈ ����1"},
                new Models.Event() { EventNo = 5, WriteId = "ABC@gamil.com", Title = "�̺�Ʈ2", Content = "�̺�Ʈ ����2"},
                new Models.Event() { EventNo = 6, WriteId = "ABC@gamil.com", Title = "�̺�Ʈ3", Content = "�̺�Ʈ ����3"}

            );
            #endregion Event Seed

            #region Notification Seed
            context.Notifications.AddOrUpdate(x => x.NotificationNo,
                new Models.Notification { NotificationNo = 1, WriteId = "ABC@gamil.com", Title = "����1", Content = "��������1", PictureName = "abc.jpg", PicturePath = "/images/notification/" },
                new Models.Notification { NotificationNo = 2, WriteId = "ABC@gamil.com", Title = "����2", Content = "��������2", PictureName = "abc.jpg", PicturePath = "/images/notification/" },
                new Models.Notification { NotificationNo = 3, WriteId = "ABC@gamil.com", Title = "����3", Content = "��������3", PictureName = "abc.jpg", PicturePath = "/images/notification/" }
            );
            #endregion Notification Seed
        }
    }
}
