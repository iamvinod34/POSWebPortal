$(document).ready(function () {
    ///Search for  Store / Location / LocationID -Srikanth
    $('#txtCategory').keyup(function () {
        $('.locData').hide();
        $('#NoRecords').hide();
        var searchText = $('#txtCategory').val().toLocaleLowerCase();
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
    $(".MasterCStore").click(function () {
        var locID = $(this).attr('data-CategoryID');
        $.ajax({
            url: '../Category/GetCategoryById',
            data: { 'CategoryID': locID },
            type: "post",
            cache: false,
            success: function (data) {
                $('#CategoryDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting Category data from server. Please try again.'
                });
                
            }
        });
    });

    $("#btnNewCStore").click(function () {
        var locID = $(this).attr('data-CategoryID');
        $.ajax({
            url: '../Category/GetCategoryById',
            data: { 'CategoryID': null },
            type: "post",
            cache: false,
            success: function (data) {
                $('#CategoryDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting New Category data from server. Please try again.'
                });
                
            }
        });
    });

});