$(document).ready(function () {
    ///Search for  Store / Location / LocationID -Srikanth
    $('#txtCity').keyup(function () {
        $('.locData').hide();
        $('#NoRecords').hide();
        var searchText = $('#txtCity').val().toLocaleLowerCase();
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
    $(".MasterCityStore").click(function () {
        var locID = $(this).attr('data-CityID');
        $.ajax({
            url: '../City/GetCityById',
            data: { 'CityID': locID },
            type: "post",
            cache: false,
            success: function (data) {
                $('#CityDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting City data from server. Please try again.'
                });
            }
        });
    });

    $("#btnNewCityStore").click(function () {
        var locID = $(this).attr('data-CityID');
        $.ajax({
            url: '../City/GetCityById',
            data: { 'CityID': null },
            type: "post",
            cache: false,
            success: function (data) {
                $('#CityDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting New City data from server. Please try again.'
                });
            }
        });
    });

});