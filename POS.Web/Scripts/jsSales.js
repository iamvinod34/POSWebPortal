$(document).ready(function () {
    //$('.datepicker').datepicker();
    
    //$('input.typeahead').typeahead({
    //    name: 'accounts',
    //    local: ['Audi', 'BMW', 'Bugatti', 'Ferrari', 'Ford', 'Lamborghini', 'Mercedes Benz', 'Porsche', 'Rolls-Royce', 'Volkswagen']
    //});
    $('#EnquiryGrid').DataTable();
    $('.gridSearch1').keyup(function () {
        $('.rowSearch').hide();
        var searchText = $(this).val();
        //var columnIndex = $(this).attr('data-column');
        var grid = $('#tbEnquiryGrid');
        var searchExists = false;
        var txtLength = searchText.length;
        if (txtLength >= 2) {
            $(grid).children('tr').each(function () {
                var tr = $(this);
                var txt0 = $('#SearchDocumentID').val().trim();
                var txt1 = $('#SearchLocation').val().trim();
                var txt2 = $('#SearchDate').val().trim();
                var txt3 = $('#SearchCustomer').val().trim();
                var txt4 = $('#SearchAmount').val().trim();
                var txt5 = $('#SearchUser').val().trim();
                var td0 = tr.children('td').eq(0);
                var td1 = tr.children('td').eq(1);
                var td2 = tr.children('td').eq(2);
                var td3 = tr.children('td').eq(3);
                var td4 = tr.children('td').eq(4);
                var td5 = tr.children('td').eq(5);
                var td0Text = $(td0).text();
                var td1Text = $(td1).text();
                var td2Text = $(td2).text();
                var td3Text = $(td3).text();
                var td4Text = $(td4).text();
                var td5Text = $(td5).text();
                if (td0Text.toLowerCase().indexOf(txt0.toLowerCase()) >= 0 && txt0.length >= 2) {
                    //tr.show();
                    searchExists = true;
                }
                if (td1Text.indexOf(txt1.toLowerCase()) >= 0 && txt1.length >= 2) {
                    tr.show();
                    searchExists = true;
                }
                if (td2Text.toLowerCase().indexOf(txt2.toLowerCase()) >= 0 && txt2.length >= 2) {
                    tr.show();
                    searchExists = true;
                }

                if (td3Text.toLowerCase().indexOf(txt3.toLowerCase()) >= 0 && txt3.length >= 2) {
                    tr.show();
                    searchExists = true;
                }
                if (td4Text.toLowerCase().indexOf(txt4.toLowerCase()) >= 0 && txt4.length >= 2) {
                    tr.show();
                    searchExists = true;
                }
                if (td5Text.toLowerCase().indexOf(txt5.toLowerCase()) >= 0 && txt5.length >= 2) {
                    tr.show();
                    searchExists = true;
                }
            });
            if (!searchExists) {
                $('#NoRecords').show();
            }
        }
        else {
            $('.rowSearch').show();
        }

    });

});