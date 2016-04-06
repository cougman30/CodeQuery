namespace MyApp.Filters
{
    function HotTopic()
    {
        return function (input, length: number)
        {
            let result = [];
            angular.forEach(input, function (value, key)
            {
                angular.forEach(value, function (value2, key2)
                {
                    if (value2 >= length)
                    {
                        result.push(value2);
                    }
                })
            });
            return result;
        }
    }

    function Recent()
    {
        return function (input, length: number)
        {
            let result = [];
            angular.forEach(input, function (value, key)
            {
                angular.forEach(value, function (value2, key2)
                {
                    if (value2 >= length)
                    {
                        result.push(value2);
                    }
                })
            });
            return result;
        }
    }
}