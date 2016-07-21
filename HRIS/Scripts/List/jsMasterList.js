//$(document).ready(function () {
    console.log("List General Function");
    var name = [];
    function jsLOV(name) {
        if (name == null) {
            console.log('Null of ', name);
            name = getLOV(name);
        } 
        return name;    
    }

    function getLOV(name) {
        var Locationsource = {
            datatype: "json",
            dataFields: [
                { name: 'value', type: 'number' },
                { name: 'label', type: 'string' }
            ],
            url: '/api/list/' + name,
            async: false
        };

        return jsListLocation = new $.jqx.dataAdapter(Locationsource, {
            autoBind: true,
            contentType: 'application/json; charset=utf-8'
        });
    }
    //================================================================================

//});


/*
console.log('jsMasterList Loaded');
//================================================================================
var jsCountries = new Array("Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antarctica", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo, Democratic Republic", "Congo, Republic of the", "Costa Rica", "Cote d'Ivoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Greenland", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea, North", "Korea, South", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Mongolia", "Morocco", "Monaco", "Mozambique", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Samoa", "San Marino", " Sao Tome", "Saudi Arabia", "Senegal", "Serbia and Montenegro", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "Spain", "Sri Lanka", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe");
//================================================================================
var jsParentCategorySource = {
    datatype: "json",
    datafields: [
        { name: 'id', type: 'number' },
        { name: 'uid', type: 'string' },
        { name: 'uidparent', type: 'string' },
        { name: 'uidname', type: 'string' },
        { name: 'uidtype', type: 'string' }
    ],
    url: '/api/categoryParents',
    async: false,
    cached: false
};

var jsListParentCategory = new $.jqx.dataAdapter(jsParentCategorySource, {
    autoBind: true,
    contentType: 'application/json; charset=utf-8'
});
//console.log('Category Parent ', jsListParentCategory);
//================================================================================
console.log("Line jsCategory");
function jsCategory(id) {
    var CategoryParentSource = {
        datatype: "json",
        datafields: [
            { name: 'id', type: 'number' },
            { name: 'uid', type: 'string' },
            { name: 'uidparent', type: 'int' },
            { name: 'uidname', type: 'string' },
            { name: 'categoryparent', type: 'string' }
        ],
        url: '/api/Common/Catparents/' + id,
        async: false
    };

    var jsListCategory = new $.jqx.dataAdapter(CategoryParentSource, {
        autoBind: true,
        contentType: 'application/json; charset=utf-8'
    });
    //console.log("Function: ");
    //console.log(jsListCategory.records)
    return jsListCategory.records;
}
//================================================================================
console.log("Line jsRegion");
function jsRegion(id) {
    var Locationsource = {
        datatype: "json",
        dataFields: [
            { name: 'id', type: 'number' },
            { name: 'uidparent', type: 'number' },
            { name: 'uidtype', type: 'number' },
            { name: 'uidname', type: 'string' }
        ],
        url: '/api/Common/Loc/' + id,
        async: false
    };

    return jsListLocation = new $.jqx.dataAdapter(Locationsource, {
        autoBind: true,
        contentType: 'application/json; charset=utf-8'
    });
}
//================================================================================

*/