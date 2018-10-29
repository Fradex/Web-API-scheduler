using Microsoft.EntityFrameworkCore.Migrations;

namespace MonitoringService.Migrations
{
    public partial class m2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MessageTypes",
                columns: new[] { "Id", "MessageName" },
                values: new object[,]
                {
                    { -90502, "Претензия (официальная) (исходящий)" },
                    { 1031, "Адреса" },
                    { 1261, "ТС по договору" },
                    { 1271, "Документ клиента" },
                    { 1435, "Марка автомобиля" },
                    { 1436, "Модель автомобиля" },
                    { 1440, "Продукт" },
                    { 1522, "Обращение ТС(Диасофт)" },
                    { 1843, "Договор страхования" },
                    { 2266, "Контактные данные" },
                    { 2845, "Распределение действий маркетинговой кампании" },
                    { 1002, "Юридические лица" },
                    { 4444, "Поток \"Заявки СОА\"" },
                    { 91001, "Физические лица (исходящий)" },
                    { 91002, "Юридические лица (исходящий)" },
                    { 91031, "Адреса (исходящий)" },
                    { 91271, "Документ клиента (исходящий)" },
                    { 91522, "Обращение ТС (исходящий)" },
                    { 92266, "Контактные данные (исходящий)" },
                    { 102035, "Задача (новая)" },
                    { 1001001, "SMS" },
                    { 1001002, "SMS Config" },
                    { 1001003, "AttemptToSend" },
                    { 4542, "Офис/СТОА" },
                    { 1001004, "DeliveryResult" },
                    { 50, "Дисквалификация интересов (новый)" },
                    { 5, "Пользователь AD" },
                    { -90035, "Задача (исходящий)" },
                    { -90024, "Заявка на вызовАК/эвакуатора CRM -> СЭД ДО 24(исходящий)" },
                    { -90023, "Запись календаря (исходящий)" },
                    { -90022, "Заявка на авторизацию полиса" },
                    { -90017, "Заявка на проверку ДБ / ПЭ (исходящий)" },
                    { -502, "Претензия (официальная)" },
                    { -501, "Претензия (досудебная)" },
                    { -102, "Убыток CRM <- СЭД ДО2" },
                    { -101, "Убыток CRM <- СЭД ДО1" },
                    { -39, "Уведомления CRM <- СЭД ДО39" },
                    { 30, "Отправка уведомлений о наступлении даты окончания кампании" },
                    { -35, "Поток \"Задача\"" },
                    { -23, "Запись календаря" },
                    { -22, "Заявка на авторизацию полиса" },
                    { -17, "Заявка на проверку ДБ / ПЭ" },
                    { -3, "Аварийные комиссары" },
                    { -2, "Обращение ТС(СЭД Каско)" },
                    { -1, "Обращение ТС(СЭД Осаго)" },
                    { 1, "Расчет мощности Офиса/СТОА" },
                    { 2, "Set Client Prolongation" },
                    { 3, "Отправка писем" },
                    { 4, "Avaya Integration" },
                    { -24, "Заявка на вызовАК/эвакуатора CRM <- СЭД ДО 24(входящий)" },
                    { 1001005, "Balance" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -90502);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -90035);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -90024);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -90023);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -90022);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -90017);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -502);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -501);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -102);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -101);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -39);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -35);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -24);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1261);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1271);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1435);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1436);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1440);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1522);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1843);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 2266);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 2845);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 4444);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 4542);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 91001);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 91002);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 91031);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 91271);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 91522);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 92266);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 102035);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1001001);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1001002);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1001003);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1001004);

            migrationBuilder.DeleteData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1001005);
        }
    }
}
