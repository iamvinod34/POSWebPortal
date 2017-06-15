$(document).ready(function () {
  
    $('#txtVLocationSearch').keyup(function () {
        $('.VlocData').hide();
        $('#NoRecords').hide();
        var searchText = $('#txtVLocationSearch').val().toLocaleLowerCase();
        var txtLength = searchText.length;
        var searchExists = false;
        if (txtLength >= 2) {

            $('.VlocData').each(function () {
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
            $('.VlocData').show();
        }
    });

   
    $(".MasterVStore").click(function () {
        var locID = $(this).attr('data-VendorID');
        $.ajax({
            url: '../Vendor/GetByVendorId',
            data: { 'VendorID': locID },
            type: "post",
            cache: false,
            success: function (data) {
                $('#VendorDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting Vendor data from server. Please try again.'
                });
            }
        });
    });

    $("#btnNewVendor").click(function () {
        var locID = $(this).attr('data-VendorID');
        $.ajax({
            url: '../Vendor/GetByVendorId',
            data: { 'VendorID': null },
            type: "post",
            cache: false,
            success: function (data) {
                $('#VendorDetails').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                var type = BootstrapDialog.TYPE_WARNING;
                BootstrapDialog.show({
                    type: type,
                    title: 'Error',
                    message: 'Error in geting New Vendor data from server. Please try again.'
                });
            }
        });
    });

});