

window.onload = function () {
    var paginationPage = parseInt($('.cdp').attr('actpage'), 10);
    $('.cdp_i').on('click', function () {
        $('#latestProducts').fadeOut('fast');
        var go = $(this).attr('href').replace('#!', '');
        if (go === '+1') {
            paginationPage++;
        } else if (go === '-1') {
            paginationPage--;
        } else {
            paginationPage = parseInt(go, 10);
        }

        $.ajax({
            url: '/partial/product/latest',
            method: 'get',
            data: { startindex: paginationPage, itemcount: 6 },
            success: function (response) {
                $('#latestProducts').html(response);
            }
        })
        $('#latestProducts').fadeIn('fast');

        $('.cdp').attr('actpage', paginationPage);
    });
};


//window.onload = function () {
//    $('.category_item').click(function () {
//        let catid = $(this).data('category');
//        $('#latestProducts').fadeOut('fast');
//        $.ajax({
//            url: '/partial/product/latest',
//            method: 'get',
//            data: { startindex: 0, itemcount: 6, categoryid:catid },
//            success: function (response) {
//                $('#latestProducts').html(response);
//            }
//        })
//        $('#latestProducts').fadeIn('fast');
//    })
//}



function AddtoBasket(p_id) {
    var product = localStorage.getItem('basket_'+p_id);
    var newcount = 0;
    if (product == null) {
        newcount = 1;
    }
    else {
        newcount = parseInt(product) + 1;
    }

    $.ajax({
        url: '/product/addtobasket/',
        type: 'post',
        data: { productid: p_id, quantity: newcount },
        success: function (res) {
            if (res.status) {

                localStorage.setItem("basket_"+p_id, newcount);
                $('#sidetotal').html('$' + res.total)
                let itemcount = 0;
                for (let i = 0; i < localStorage.length; i++) {
                    if (localStorage.key(i).includes('basket_')) {
                        itemcount++;
                    }
                }
                $('.itemcount').html(itemcount)
            }
            else {
                alertify.error(res.message);
            }
        },
        error: function (err) {

        }
    })
}