$(document).ready(function () {
    ///Search for  Store / Location / LocationID -Srikanth
    $('#txtSubCategory').keyup(function () {
        $('.locData').hide();
        $('#NoRecords').hide();
        var searchText = $('#txtSubCategory').val().toLocaleLowerCase();
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
    $(".MasterSCStore").click(function () {
        var locID = $(this).attr('data-subCategoryID');
        $.ajax({
            url: '../SubCategory/GetSubCategoryByID',
            data: { 'SubCategoryID': locID },
            type: "post",
            cache: false,
            success: function (data) {
                $('#SubCategoryDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting Sub Category data from server. Please try again.'
                });
            }
        });
    });

    $("#btnNewSCStore").click(function () {
        var locID = $(this).attr('data-CategoryID');
        $.ajax({
            url: '../SubCategory/GetSubCategoryByID',
            data: { 'SubCategoryID': null },
            type: "post",
            cache: false,
            success: function (data) {
                $('#SubCategoryDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting New Sub Category data from server. Please try again.'
                });
            }
        });
    });

});