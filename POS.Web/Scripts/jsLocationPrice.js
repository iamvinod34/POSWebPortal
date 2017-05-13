$(document).ready(function () {
    ///Search for  Store / Location / LocationID -Srikanth
    $('#txtLocationPrice').keyup(function () {
        $('.locData').hide();
        $('#NoRecords').hide();
        var searchText = $('#txtLocationPrice').val().toLocaleLowerCase();
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
    $(".MasterLocationPriceStore").click(function () {
        var locID = $(this).attr('data-LocationID');
        var EAN13 = $(this).attr('data-EAN13');
        $.ajax({
            url: '../LocationPrice/LocationPriceGetByID',
            data: { 'LocationID': locID, 'EAN13': EAN13 },
            type: "post",
            cache: false,
            success: function (data) {
                $('#LocationPriceDetails').html(data);
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

    $("#btnNewLocationPriceStore").click(function () {
        var locID = $(this).attr('data-RegionID');
        var EAN13 = $(this).attr('data-EAN13');
        $.ajax({
            url: '../LocationPrice/LocationPriceGetByID',
            data: { 'LocationID': locID, 'EAN13': EAN13 },
            type: "post",
            cache: false,
            success: function (data) {
                $('#LocationPriceDetails').html(data);
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