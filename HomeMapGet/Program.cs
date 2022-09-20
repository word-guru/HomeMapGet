var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var message = "1. Необходимо создать веб приложение со страницей (/customs_duty),"
              + "которая будет вычислять размер таможенной пошлины:"
              + "в параметре price передается стоимость посылки."
              + "Пошлина начисляется при превышении 200€, а ее размер равен 15% от суммы превышения.\n\n";
message += @"2. * Реализуйте страницу, которая будет показывать текущую дату и время
в полном формате (включая название дня недели и месяца), на языке, переданном в параметре
language. Параметр language передается в формате ISO 639-1 (ru, en, fr, cn и т. д.).";

app.MapGet("/", () => message);

app.MapGet("/customs_duty", (decimal? price) =>
{
    var exceedingCost = price - 200;

    if (exceedingCost == 0)
        return $"Пошлина: {exceedingCost} $";
    else
        return $"Пошлина: {exceedingCost / 100 * 15} $";
});

app.MapGet("/date_time", (string language) => 
DateTime.Now.ToString("U", new System.Globalization.CultureInfo(language).DateTimeFormat));

app.Run();
