# 1
Я исключил лишние атрибуты с помощью [JsonIgnore] и оставил только objects, conditions, options и timeConstraint. 
Настроил [JsonProperty("property_name")] для этих атрибутов. 

Даработал метод QueryData, чтобы получать список json объектов, а также добавил в static void Main вывод в консоль для проверки.
В итоге вывод соответсвует примеру jsonResult.
