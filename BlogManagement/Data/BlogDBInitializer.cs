using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BlogManagement.Data
{
    public class BlogDBInitializer : CreateDatabaseIfNotExists<DAL.Entities.BlogDBContext>
    {
        protected override void Seed(DAL.Entities.BlogDBContext context)
        {

            context.Accounts.Add(new DAL.Entities.Account() { Email = "minhbeo@gmail.com", PassWord = "111111", isAdmin = false, EmailConfirmed = true, UserName = "MinhFat", Image = "" });
            context.Accounts.Add(new DAL.Entities.Account() { Email = "quankun@gmail.com", PassWord = "111111", isAdmin = true, EmailConfirmed = true, UserName = "QuanKun", Image = "" });
            context.Accounts.Add(new DAL.Entities.Account() { Email = "ducanh@gmail.com", PassWord = "111111", isAdmin = true, EmailConfirmed = true, UserName = "AnhDzz", Image = "" });
            context.SaveChanges();

            context.Categories.Add(new DAL.Entities.Category() { Name = "Khoa học" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Cộng nghệ" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Giải trí" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Nhảm nhí" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Đàn ông" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Phụ nữ" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Âm nhạc" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Phim ảnh" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Người lớn" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Người hơi lớn" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Trẻ em" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Dành cho người không biết chữ" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Đàn ông mang thai" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Trẻ em cho con bú" });
            context.Categories.Add(new DAL.Entities.Category() { Name = "Khác..." });

            context.SaveChanges();


            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 1,
                CategoryId = 1,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 2,
                CategoryId = 3,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 3,
                CategoryId = 5,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 1,
                CategoryId = 4,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 2,
                CategoryId = 6,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 3,
                CategoryId = 7,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 1,
                CategoryId = 8,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 2,
                CategoryId = 9,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 3,
                CategoryId = 1,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 1,
                CategoryId = 3,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 2,
                CategoryId = 3,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 3,
                CategoryId = 2,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 1,
                CategoryId = 4,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 2,
                CategoryId = 5,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 3,
                CategoryId = 1,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });
            context.Posts.Add(new DAL.Entities.Post()
            {
                AccountId = 1,
                CategoryId = 5,
                Content = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Beatae nihil possimus excepturi ab repudiandae sit veniam provident deleniti reprehenderit " +
                "architecto nemo et corrupti molestias magnam ratione vel cum totam exercitationem, vitae qui voluptatum voluptates pariatur eos " +
                "obcaecati? Asperiores perspiciatis modi incidunt, qui dicta reprehenderit ducimus iure animi! " +
                "Laboriosam corrupti ut nisi. Aliquam eveniet sapiente tenetur labore quo perferendis delectus voluptate similique voluptas optio" +
                " atque, eius qui fugiat quis. Quam possimus ab, magnam est aut perferendis aspernatur, facere " +
                "doloremque repellendus, nihil harum velit cum autem impedit ducimus. Blanditiis tenetur quam laudantium quod quos, voluptates asperiores aliquid, dolore alias, aperiam quia saepe.",
                DatePost = DateTime.Now.AddDays(-2),
                Title = "Tiêu đề",
                Likes = 0
            });

            context.SaveChanges();
        }
    }
}