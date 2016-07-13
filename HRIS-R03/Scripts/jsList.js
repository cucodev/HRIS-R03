// OLD ================================================================================ OLD 
var countries = new Array("Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antarctica", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burma", "Burundi", "Cambodia", "Cameroon", "Canada", "Cape Verde", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo, Democratic Republic", "Congo, Republic of the", "Costa Rica", "Cote d'Ivoire", "Croatia", "Cuba", "Cyprus", "Czech Republic", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "East Timor", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Greenland", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Korea, North", "Korea, South", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macedonia", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Mongolia", "Morocco", "Monaco", "Mozambique", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Samoa", "San Marino", " Sao Tome", "Saudi Arabia", "Senegal", "Serbia and Montenegro", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "Spain", "Sri Lanka", "Sudan", "Suriname", "Swaziland", "Sweden", "Switzerland", "Syria", "Taiwan", "Tajikistan", "Tanzania", "Thailand", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe");
//================================================================================
var CategorySource = {
    datatype: "json",
    datafields: [
        { name: 'id', type: 'number' },
        { name: 'uid', type: 'string' },
        { name: 'uidparent', type: 'int' },
        { name: 'uidname', type: 'string' },
        { name: 'categoryparent', type: 'string' }
    ],
    url: '/api/category/',
    async: false
};

var listCategory = new $.jqx.dataAdapter(CategorySource, {
    autoBind: true,
    contentType: 'application/json; charset=utf-8'
});

//================================================================================
function catParents(id) {
    var CategoryParentSource = {
        datatype: "json",
        datafields: [
            { name: 'id', type: 'number' },
            { name: 'uid', type: 'string' },
            { name: 'uidparent', type: 'int' },
            { name: 'uidname', type: 'string' },
            { name: 'categoryparent', type: 'string' }
        ],
        url: '/api/Common/CatParents/' + id,
        async: false
    };

    var listParentCategory = new $.jqx.dataAdapter(CategoryParentSource, {
        autoBind: true,
        contentType: 'application/json; charset=utf-8'
    });
    return listParentCategory;
}

//================================================================================

var EmployeeSource = {
    dataType: "json",
    dataFields: [
        { name: 'ID', type: 'number' },
        { name: 'UID', type: 'string' },
        { name: 'Name', type: 'string' },
        { name: 'NickName', type: 'string' },
        { name: 'Religion', type: 'string' },
        { name: 'UID_Absence', type: 'number' },
        { name: 'empStatus', type: 'string' },
        { name: 'Gender', type: 'string' }
    ],
    url: '/api/emp_master',
    async: false
};

var listEmployee = new $.jqx.dataAdapter(EmployeeSource, {
    autoBind: true,
    contentType: 'application/json; charset=utf-8'
});

//================================================================================

function ListRegion(div, value) {
    var Locationsource = {
        datatype: "json",
        dataFields: [
            { name: 'id', type: 'number' },
            { name: 'uidname', type: 'string' }
        ],
        url: '/api/Common/Loc/' + value
    };

    return listLocation = new $.jqx.dataAdapter(Locationsource, {
        autoBind: true,
        contentType: 'application/json; charset=utf-8'
    });
}

//================================================================================
function ListJob(div, value) {
    var Jobsource = {
        datatype: "json",
        dataFields: [
            { name: 'id', type: 'number' },
            { name: 'uidname', type: 'string' }
        ],
        url: '/api/Common/Catparents/' + value
    };

    return listJobs = new $.jqx.dataAdapter(Jobsource, {
        autoBind: true,
        contentType: 'application/json; charset=utf-8'
    });
}
//================================================================================
var religion = [
    "Islam",
    "Christian",
    "Catholic",
    "Budhiesm",
    "Hinduism"
];
//================================================================================
var Gender = [
    { label: 'Male', value: 'M' },
    { label: 'Female', value: 'F'}
]
//================================================================================