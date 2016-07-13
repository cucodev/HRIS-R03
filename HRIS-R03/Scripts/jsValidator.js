/*
    idDivArray merupakan nama id dari element form yang akan dilakukan validasi
*/
function notNull(idDivArray) {
    var counter = 0;
    $.each(idDivArray, function (index, value) {
        if ($("#" + value).val() == "") {
            counter = counter + 1;
            $("#" + value).closest(".form-group").removeClass("has-success").addClass("has-error");
        } else {
            $("#" + value).closest(".form-group").removeClass("has-error").addClass("has-success");
        }
    });
    counter > 0 ? $("#SubmitButton").removeClass("btn-default").addClass("btn-danger") : $("#SubmitButton").removeClass("btn-danger").addClass("btn-default");
    return counter;
}