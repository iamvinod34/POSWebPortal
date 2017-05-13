$(document).ready(function () {
    ///Search for  Store / Location / LocationID -Srikanth
    $('#txtCountry').keyup(function () {
        $('.locData').hide();
        $('#NoRecords').hide();
        var searchText = $('#txtCountry').val().toLocaleLowerCase();
        var txtLength = searchText.length;
        var searchExists = false;
        if (txtLength >= 2) {

            $('.locData').each(function () {
                var locText = $(this).html();
                if (locText.toLowerCase().indexOf(searchText) >= 0) {
                    $(this).show();
                    searchExists = true;
                }
            });
            if (!searchExists) {
                $('#NoRecords').show();
            }
        }
        else {
            $('.locData').show();
        }
    });

    ///On selecting location/store get details by id -Srikanth
    $(".MasterCountryStore").click(function () {
        var locID = $(this).attr('data-CountryID');
        $.ajax({
            url: '../Country/GetCountryById',
            data: { 'CountryID': locID },
            type: "post",
            cache: false,
            success: function (data) {
                $('#CountryDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting Country data from server. Please try again.'
                });
                
            }
        });
    });

    $("#btnNewCountryStore").click(function () {
        var locID = $(this).attr('data-CountryID');
        $.ajax({
            url: '../Country/GetCountryById',
            data: { 'CountryID': 0 },
            type: "post",
            cache: false,
            success: function (data) {
                $('#CountryDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting New Country data from server. Please try again.'
                });
            }
        });
    });

});