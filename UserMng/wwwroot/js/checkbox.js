$('#checkBoxMain').click(function () {
    if ($(this).is(':checked')) {
        $('#table input:checkbox').prop('checked', true);
    } else {
        $('#table input:checkbox').prop('checked', false);
    }
};
$('#table input:checkbox').click(function () {
    $('#checkBoxMain').prop('checked', false);
});
