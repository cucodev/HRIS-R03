//Fill IN FORM
IN('IDParent');
IN('IDParentLevel');
IN('UID');
IN('Name');
IN('NickName');
IN('Religion');
IN('Gender');
IN('Gender');
IN('Marital');
IN('NIP');

IN('Birthdate');
IN('Birthplace');
IN('Nationality');

IN('empEdu');
IN('empEduMajor');

IN('empDepartement');
IN('empDivision');
IN('empJobLevel');
IN('empOfficeLocation');
IN('empPosition');

IN('Phone1');
IN('Phone2');

IN('Address');
IN('AddressKec');
IN('AddressKel');
IN('AddressKab');
IN('AddressProv');

IN('UID_ABSENCE');
IN('empStatus');
IN('rowStatus');

//Fill IN FORM
function IN(idval) {
    try {
        var str = eval('dt.' + idval);
        $('#' + idval).val(str);
    } catch (err) {
        console.log('Error : ' + idval + ' ' + err);
    }

}
