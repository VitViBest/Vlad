using Pharmacy.DAL.Entities.Store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DAL.EF
{
    class DbInitializer :DropCreateDatabaseIfModelChanges<MainContext>
    {
        protected override void Seed(MainContext context)
        {
            Kind[] kinds = new Kind[3];
            Kind kind1 = new Kind() {
                Name = "Механические головоломки",
                Text = "Механическая головоломка — это головоломка, представленная в виде набора механически сцеплённых частей.",
                Photo = "https://images.ua.prom.st/1745107611_kubik-rubika-melnitsa.jpg",
            };
            Kind kind2 = new Kind()
            {
                Name = "Кубик Рубика",
                Text = "Кубик Рубика – увлекательная и очаровательная механическая головоломка изобретенная в 1974 г. Эрнё Рубиком.",
                Photo = "https://toptos.com.ua/content/images/29/professionalnyy-kubik-rubik-3kh3-gan-356-air-sm-68203372756640_small11.png",
            };
            Kind kind3 = new Kind()
            {
                Name = "Металлические головоломки",
                Text = "Головоломка металлическая – это замысловатая фигурка, элементы которой в процессе разгадывания придется разъединить и соединить снова.",
                Photo = "https://kubik.in.ua/upload/iblock/113/6d197e7b-32bf-11e8-97ed-3a6561333536_3e60fc80-c18f-11e8-a7d7-3a6561333536.jpg",
            };
            kinds = new[] { kind1,kind2,kind3 };
            //Producer producer1 = new Producer() { Name = "QI", Country = "США", Address = "Нью Йорк 45", Number = "+5999134122" };
            //context.Producers.Add(producer1);
            //Image image1 = new Image() { Text = "Model 1", Photo = File.ReadAllBytes(@"C:\Users\User\source\repos\Pharmacy\Pharmacy.DAL\Test_Images\5cc34849daa9a964f25e28e9-750-500.jpg") };
            //Image image2 = new Image() { Text = "Model 2", Photo = File.ReadAllBytes(@"C:\Users\User\source\repos\Pharmacy\Pharmacy.DAL\Test_Images\best-smartphones-2018-728x500-728x500.jpg") };
            //Image image3 = new Image() { Text = "Model 3", Photo = File.ReadAllBytes(@"C:\Users\User\source\repos\Pharmacy\Pharmacy.DAL\Test_Images\Huawei-P20-2.jpg") };
            //Image[] images = new Image[3];
            //images = new[] { image1, image2, image3 };
            //Property property1 = new Property() { Name = "Возраст", Text = "от 12" };
            //Property property2 = new Property() { Name = "Возраст", Text = "от 13" };
            //Property property3 = new Property() { Name = "Возраст", Text = "от 14" };
            //Property[] properties = new Property[3];
            //properties = new[] { property1, property2, property3 };
            //context.Kinds.AddRange(kinds);
            //context.Images.AddRange(images);
            //context.Properties.AddRange(properties);
            //Product product1 = new Product
            //{
            //    Name = "Xiaomi Redmi Note 4X",
            //    Price = 5000.00M,
            //    Description = "Стильный, модный, надежный.",
            //    Producer = producer2,
            //    Kinds = new List<Kind> { kind1, kind2 },
            //    Images = new List<Image> { image1, image2 },
            //    Properties = new List<Property> { property1, property4, property7 },
            //    IsDeleted = false
            //};
            //Product product2 = new Product
            //{
            //    Name = "Samsung A2",
            //    Price = 1000.00M,
            //    Description = "В принципе норм.",
            //    Producer = producer1,
            //    Kinds = new List<Kind> { kind3, kind2 },
            //    Images = new List<Image> { image3 },
            //    Properties = new List<Property> { property2, property5, property8 },
            //    IsDeleted = false
            //};
            //Product product3 = new Product
            //{
            //    Name = "Xiaomi Redmi Note 7",
            //    Price = 8000.00M,
            //    Description = "Идеальный вариант.",
            //    Producer = producer2,
            //    Kinds = new List<Kind> { kind3, kind1 },
            //    Images = new List<Image> { image4, image5 },
            //    Properties = new List<Property> { property3, property6, property9 },
            //    IsDeleted = false
            //};
            //context.Products.Add(product1);
            //context.Products.Add(product2);
            //context.Products.Add(product3);
            context.Kinds.AddRange(kinds);
            base.Seed(context);
        }
    }
}
