var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var message = "1. ���������� ������� ��� ���������� �� ��������� (/customs_duty),"
              + "������� ����� ��������� ������ ���������� �������:"
              + "� ��������� price ���������� ��������� �������."
              + "������� ����������� ��� ���������� 200�, � �� ������ ����� 15% �� ����� ����������.\n\n";
message += @"2. * ���������� ��������, ������� ����� ���������� ������� ���� � �����
� ������ ������� (������� �������� ��� ������ � ������), �� �����, ���������� � ���������
language. �������� language ���������� � ������� ISO 639-1 (ru, en, fr, cn � �. �.).";

app.MapGet("/", () => message);

app.MapGet("/customs_duty", (decimal? price) =>
{
    var exceedingCost = price - 200;

    if (exceedingCost == 0)
        return $"�������: {exceedingCost} $";
    else
        return $"�������: {exceedingCost / 100 * 15} $";
});

app.MapGet("/date_time", (string language) => 
DateTime.Now.ToString("U", new System.Globalization.CultureInfo(language).DateTimeFormat));

app.Run();
