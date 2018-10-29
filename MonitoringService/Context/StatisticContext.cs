using Microsoft.EntityFrameworkCore;
using MonitoringService.Model;

namespace MonitoringService.Context
{
	public class StatisticContext : DbContext
	{
		public StatisticContext()
		{
		}

		public StatisticContext(DbContextOptions<StatisticContext> options)
			: base(options)
		{
		}

		public virtual DbSet<BusQueueStatistic> BusQueueStatistics { get; set; }
		public virtual DbSet<MessageType> MessageTypes { get; set; }

		/// <inheritdoc />
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<MessageType>().HasData(
				new { Id = -90502, MessageName = "Претензия (официальная) (исходящий)" },
				new { Id = -90035, MessageName = "Задача (исходящий)" },
				new { Id = -90024, MessageName = "Заявка на вызовАК/эвакуатора CRM -> СЭД ДО 24(исходящий)" },
				new { Id = -90023, MessageName = "Запись календаря (исходящий)" },
				new { Id = -90022, MessageName = "Заявка на авторизацию полиса" },
				new { Id = -90017, MessageName = "Заявка на проверку ДБ / ПЭ (исходящий)" },
				new { Id = -502, MessageName = "Претензия (официальная)" },
				new { Id = -501, MessageName = "Претензия (досудебная)" },
				new { Id = -102, MessageName = "Убыток CRM <- СЭД ДО2" },
				new { Id = -101, MessageName = "Убыток CRM <- СЭД ДО1" },
				new { Id = -39, MessageName = "Уведомления CRM <- СЭД ДО39" },
				new { Id = -35, MessageName = "Поток \"Задача\"" },
				new { Id = -24, MessageName = "Заявка на вызовАК/эвакуатора CRM <- СЭД ДО 24(входящий)" },
				new { Id = -23, MessageName = "Запись календаря" },
				new { Id = -22, MessageName = "Заявка на авторизацию полиса" },
				new { Id = -17, MessageName = "Заявка на проверку ДБ / ПЭ" },
				new { Id = -3, MessageName = "Аварийные комиссары" },
				new { Id = -2, MessageName = "Обращение ТС(СЭД Каско)" },
				new { Id = -1, MessageName = "Обращение ТС(СЭД Осаго)" },
				new { Id = 1, MessageName = "Расчет мощности Офиса/СТОА" },
				new { Id = 2, MessageName = "Set Client Prolongation" },
				new { Id = 3, MessageName = "Отправка писем" },
				new { Id = 4, MessageName = "Avaya Integration" },
				new { Id = 5, MessageName = "Пользователь AD" },
				new { Id = 30, MessageName = "Отправка уведомлений о наступлении даты окончания кампании" },
				new { Id = 50, MessageName = "Дисквалификация интересов (новый)" },
				new { Id = 1001, MessageName = "Физические лица" },
				new { Id = 1002, MessageName = "Юридические лица" },
				new { Id = 1031, MessageName = "Адреса" },
				new { Id = 1261, MessageName = "ТС по договору" },
				new { Id = 1271, MessageName = "Документ клиента" },
				new { Id = 1435, MessageName = "Марка автомобиля" },
				new { Id = 1436, MessageName = "Модель автомобиля" },
				new { Id = 1440, MessageName = "Продукт" },
				new { Id = 1522, MessageName = "Обращение ТС(Диасофт)" },
				new { Id = 1843, MessageName = "Договор страхования" },
				new { Id = 2266, MessageName = "Контактные данные" },
				new { Id = 2845, MessageName = "Распределение действий маркетинговой кампании" },
				new { Id = 4444, MessageName = "Поток \"Заявки СОА\"" },
				new { Id = 4542, MessageName = "Офис/СТОА" },
				new { Id = 91001, MessageName = "Физические лица (исходящий)" },
				new { Id = 91002, MessageName = "Юридические лица (исходящий)" },
				new { Id = 91031, MessageName = "Адреса (исходящий)" },
				new { Id = 91271, MessageName = "Документ клиента (исходящий)" },
				new { Id = 91522, MessageName = "Обращение ТС (исходящий)" },
				new { Id = 92266, MessageName = "Контактные данные (исходящий)" },
				new { Id = 102035, MessageName = "Задача (новая)" },
				new { Id = 1001001, MessageName = "SMS" },
				new { Id = 1001002, MessageName = "SMS Config" },
				new { Id = 1001003, MessageName = "AttemptToSend" },
				new { Id = 1001004, MessageName = "DeliveryResult" },
				new { Id = 1001005, MessageName = "Balance" });
		}
	}
}