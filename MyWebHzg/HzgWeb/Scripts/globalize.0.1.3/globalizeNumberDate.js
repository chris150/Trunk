
// Validierung von lokalisierten double Werten
$.validator.methods.number = function (value, element)
{
    var intValue = parseInt(value);
    var globalizedValue = Globalize.parseFloat(value);
    var result = this.optional(element) || !isNaN(Globalize.parseFloat(value)) && intValue == Math.floor(globalizedValue);
    return result;
}

// Validierung von lokalisierten datetime Werten
$.validator.methods.date = function (value, element)
{
    return this.optional(element) || Globalize.parseDate(value) || Globalize.parseDate(value, "yyyy-MM-dd");
}

jQuery.extend(jQuery.validator.methods,
{
    range: function (value, element, param) {
        //Use the Globalization plugin to parse the value
        var val = Globalize.parseFloat(value);
        return this.optional(element) || (val >= param[0] && val <= param[1]);
    }
});

