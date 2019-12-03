using MovieStore.DataAccess;
using System.Linq;

namespace MovieStore.Helpers
{
    public static class DataInitializer
    {
        public static void Initialize(MovieStoreContext context)
        {
            CreateUsersIfNotExists(context);
            CreateMoviesIfNotExists(context);

            context.SaveChanges();
        }

        private static void CreateUsersIfNotExists(MovieStoreContext context)
        {
            if (context.Users.Count() != 0)
            {
                return;
            }

            var userRole = new Role { Name = "user" };
            var moderatorRole = new Role { Name = "moderator" };
            var adminRole = new Role { Name = "admin" };
            context.Roles.AddRange(new[] { userRole, moderatorRole, adminRole });

            context.Users.Add(new User()
            {
                UserName = "bohdan",
                FirstName = "Богдан",
                LastName = "Романюк",
                Role = adminRole,
                HashedPassword = "037a6a1c0c23a9b9452f79c86245af9f"
            });

            context.Users.Add(new User()
            {
                UserName = "roman",
                FirstName = "Роман",
                LastName = "Паробій",
                Role = moderatorRole,
                HashedPassword = "b179a9ec0777eae19382c14319872e1b"
            });

            context.Users.Add(new User()
            {
                UserName = "vladislav",
                FirstName = "Влад",
                LastName = "Бучелла",
                Role = userRole,
                HashedPassword = "f68438be30a21e34d7d5dc9a71dec40a"
            });
        }

        private static void CreateMoviesIfNotExists(MovieStoreContext context)
        {
            if (context.Movies.Count() != 0)
            {
                return;
            }

            context.Movies.Add(new Movie()
            {
                Price = 243,
                UkrName = "Месники: Завершення",
                OriginName = "Avengers: Endgame",
                Poster = "avengers-endgame-2019-_550.jpg",
                Year = 2019,
                Genre = "бойовик, пригоди, фантастика, фентезі",
                Country = "США",
                Length = "03:01:11",
                Companies = "Brazil Production Services, Double Negative (DNEG), Marvel Studios",
                Director = "Ентоні Руссо, Джо Руссо",
                Actors = "Роберт Дауні мол., Кріс Еванс, Марк Руффало, Кріс Гемсворт, Скарлетт Йоханссон, Джеремі Реннер, Дон Чідл, Пол Радд, Чедвік Боузман, Брі Ларсон",
                Story = "Месники і Вартові Галактики вступають в останню стадію війни з Таносом, який володіє всемогутньою Рукавичкою Нескінченності. Гряде фінальна битва між силами героїв і Божевільного Титана, що раз і назавжди визначить подальшу долю не тільки Землі, але і всього всесвіту.",
            });

            context.Movies.Add(new Movie()
            {
                Price = 110,
                UkrName = "Гра в хованки",
                OriginName = "Ready or Not",
                Poster = "1911201523595606_f0_0.jpg",
                Year = 2019,
                Genre = "детектив, жахи, трилер",
                Country = "США",
                Length = "01:35:22",
                Companies = "Mythology Entertainment, Vinson Films",
                Director = "Меттью Беттінеллі, Тайлер Джиллетт",
                Actors = "Самара Вівінг, Адам Броді, Марк О’Брайен, Генрі Черні, Енді МакДауелл, Мелані Скорфано, Джон Ралстон",
                Story = "Фільм розповідає про дівчину на ім'я Грейс, яка виходить заміж за хлопця своєї мрії і з нетерпінням чекає, коли стане частиною його великої родини. Але ніч їхнього весілля приймає несподіваний оберт, коли ексцентричні родичі вирішують влаштувати на неї полювання, оскільки вірять, що якщо не принесуть її в жертву, їх спіткає жахлива біда.",
            });

            context.Movies.Add(new Movie()
            {
                Price = 75,
                UkrName = "Воно 2",
                OriginName = "It Chapter Two",
                Poster = "it-chapter-two-2019-_1570353356_550.jpg",
                Year = 2019,
                Genre = "жахи",
                Country = "Канада, США",
                Length = "02:49:25",
                Companies = "KatzSmith Productions, Lin Pictures, New Line Cinema",
                Director = "Андрес Мускетті",
                Actors = "Джессіка Честейн, Джеймс МакЕвой, Білл Хейдер, Айзая Мустафа, Джеймс Ренсон, Енді Бін, Білл Скарсгард, Джейден Мартелл, Вайатт Олефф, Джек Грейзер",
                Story = "Коли в містечку Деррі, штат Мен, починають пропадати діти, кілька хлопців стикаються зі своїми найбільшими страхами і змушені помірятися силами зі злісним клоуном Пеннівайз, чиї прояви жорстокості і список жертв йдуть в глиб століть.",
            });

            context.Movies.Add(new Movie()
            {
                Price = 340,
                UkrName = "Одного разу в... Голлівуді",
                OriginName = "Once Upon a Time ... in Hollywood",
                Poster = "once-upon-a-time...-in-hollywood-2019-_1574283373_550.jpg",
                Year = 2019,
                Genre = "драма, комедія",
                Country = "Велика Британія, США, Китай",
                Length = "02:41:29",
                Companies = "Columbia Pictures, Bona Film Group, Heyday Films",
                Director = "Квентін Тарантіно",
                Actors = "Леонардо Ді Капріо, Бред Пітт, Марго Роббі, Еміль Хірш, Маргарет Куеллі, Тімоті Оліфант. Остін Роберт Батлер, Дакота Фаннінг, Брюс Дерн, Аль Пачіно, Люк Перрі, Курт Расселл, Майкл Медсен",
                Story = "1969 рік. Колишня зірка серіального вестерна Рік Далтон і його дублер Кліфф Бут намагаються пробитися на вершину Голлівуду після одного вдалого серіалу. По сусідству з Ріком живе відома актриса Шерон Тейт, і вони з Кліффом вирішують скористатися її зв'язками.",
            });

            context.Movies.Add(new Movie()
            {
                Price = 170,
                UkrName = "Джокер",
                OriginName = "Joker",
                Poster = "joker-2019-_1573464752_550.jpg",
                Year = 2019,
                Genre = "драма, кримінал, трилер",
                Country = "США, Канада",
                Length = "01:55:32",
                Companies = "BRON Studios, Creative Wealth Media Finance, DC Comics",
                Director = "Тодд Філліпс",
                Actors = "Хоакін Фенікс, Зазі Бітц, Роберт Де Ніро, Марк Мерон, Френсіс Конрой, Ші Уігхем, Бретт Каллен, Дуглас Ходж",
                Story = "Відчуваючи самотність, Артур Флек шукає моральну підтримку. Проте, гуляючи покинутими вулицями Ґотему та пересуваючись у розмальованому графіті громадському транспорті ворожого міста, Артур носить дві маски. Першу він використовує для повсякденної роботи клоуном. Іншої ж просто не може позбутись. Це подоба особистості, яку він проектує в марній спробі відчути себе частиною навколишнього світу, а не самотньою людиною, яку весь час шматує життя. У Артура немає батька – лише слабка матір. Вона є для нього одночасно й найкращою подругою. Мати дала йому прізвисько Щасливчик. Це прізвисько викликає в Артура посмішку, яка приховує сильний душевний біль. Проте коли на вулицях знущаються підлітки, в метро насміхаються над костюмом клоуна, а колеги злісно дражнять, Артуру не залишається іншого вибору, крім як ще більше відмежувати себе від суспільства.",
            });

            context.Movies.Add(new Movie()
            {
                Price = 56,
                UkrName = "Форсаж: Гоббс та Шоу",
                OriginName = "Fast & Furious Presents: Hobbs & Shaw",
                Poster = "hobbs-shaw-1_550.jpg",
                Year = 2019,
                Genre = "бойовик, пригодницький",
                Country = "Велика Британія, США",
                Length = "02:16:42",
                Companies = "Chris Morgan Productions, Seven Bucks Productions, Universal Pictures",
                Director = "Девід Літч",
                Actors = "Двейн Джонсон, Джейсон Стетгем, Ідріс Ельба, Ванесса Кірбі, Хелен Міррен, Ейса Гонсалес, Едді Марсан, Кліфф Кертіс",
                Story = "Під час своєї чергової місії агент дипломатичної безпеки США Люк Хоббс вирішується створити малоймовірний союз зі злочинцем Декардом Шоу. На цей раз їм доведеться залишити свої непримиренні розбіжності позаду, щоб захистити світ від небезпечної біологічної атаки.",
            });

            //context.Movies.Add(new Movie()
            //{
            //    UkrName = "",
            //    OriginName = "",
            //    Poster = "",
            //    Year = ,
            //    Genre = "",
            //    Country = "",
            //    Length = "",
            //    Companies = "",
            //    Director = "",
            //    Actors = "",
            //    Story = "",
            //});
        }
    }
}
