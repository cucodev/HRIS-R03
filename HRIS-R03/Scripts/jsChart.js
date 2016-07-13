


var dataGender = [];
var cF = 0;
var cM = 0;

var listEmployee = new $.jqx.dataAdapter(EmployeeSource, {
    //async: false,
    autoBind: true,
    contentType: 'application/json; charset=utf-8',
    loadError: function (xhr, status, error) {
        alert('Error loading "' + EmployeeSource.url + '" : ' + error);
    },
    beforeLoadComplete: function (records) {
        
        // update the loaded records. Dynamically add EmployeeName and EmployeeID fields. 
        for (var i = 0; i < records.length; i++) {
            var g = records[i];
            
            if (g.Gender == 'F') {
                cF = cF + 1;
            }
            if (g.Gender == 'M') {
                cM = cM + 1;
            }
           
        }
        //return data;
        dataGender.push({ Tipe: 'F', sumTipe: cF });
        dataGender.push({ Tipe: 'M', sumTipe: cM });
        //console.log('Female = ' + cF);
        //console.log('Male = ' + cM);
    },
    beforeSend: function () {
        
        
    },
});

var settings = {
    title: "",
    description: "",
    showLegend: false,
    enableAnimations: true,
    padding: { left: 0, top: 5, right: 20, bottom: 5 },
    titlePadding: { left: 90, top: 0, right: 0, bottom: 10 },
    source: dataGender,
    showBorderLine: false,
    xAxis:
    {
        dataField: 'Tipe',
        gridLines: { visible: true },
        flip: false
    },
    valueAxis:
    {
        flip: true,
        labels: {
            visible: false,
            formatFunction: function (value) {
                return parseInt(value / 10);
            }
        }
    },
    colorScheme: 'scheme02',
    seriesGroups:
        [
            {
                type: 'column',
                orientation: 'horizontal',
                columnsGapPercent: 50,
                toolTipFormatSettings: { thousandsSeparator: ',' },
                series: [
                        { dataField: 'sumTipe', displayText: 'jumlah' }
                ]
            }
        ]
};



