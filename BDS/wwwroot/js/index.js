var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
        loadData();
    }

    function loadData() {
        $.ajax({
            type: "GET",
            url: '/Cart/GetListItems',
            success: function (res) {
                $('.lbl_number_items_header').text(res.length);
                if (res.length === 0) {
                    $('#cart-wrapper').hide();
                    $('#emty-cart').show();
                } else {
                    $('#cart-wrapper').show();
                    $('#emty-cart').hide();
                }
                var html = '';
                var total = 0;

                $.each(res, function (i, item) {
                    var amount=0;
                    if (item.price > 0) {
                        amount = item.price * item.quantity;
                    } 
                    html += `
 <tr class="woocommerce-cart-form__cart-item cart_item">

                                                    <td class="product-remove">
							<a class="remove removeItem" data-id="` + item.productId + `" aria-label="Xóa sản phẩm này" data-product_id="409" data-product_sku="">&times;</a>	
</td>

                                                    <td class="product-thumbnail">
                                                        <a href="/san-pham/`+ item.url + `/` + item.productId + `"><img width="300" height="300" src="` + item.logo + `" class="attachment-woocommerce_thumbnail size-woocommerce_thumbnail" alt="` + item.name + `" sizes="(max-width: 300px) 100vw, 300px" /></a>
                                                    </td>

                                                    <td class="product-name" data-title="Sản phẩm">
                                                        <a href="/san-pham/`+ item.url + `/` + item.productId + `">` + item.name + `</a>							<div class="show-for-small mobile-product-price">
                                                            <span class="mobile-product-price__qty">1 x </span>
                                                        </div>
                                                    </td>

                                                    <td class="product-price" data-title="Giá">
                                                        <span class="woocommerce-Price-amount amount">` + numberWithCommas(item.price) + `&nbsp;<span class="woocommerce-Price-currencySymbol">&#8363;</span></span>
                                                    </td>

                                                    <td class="product-quantity" data-title="Số lượng">
                                                        <div class="quantity buttons_added">
                                                            <input type="button" value="-" data-id="` + item.productId + `" class="minus button is-form qty-decrease-cart">		<label class="screen-reader-text" for="quantity_626028758e985">Số lượng</label>
                                                            <input type="number"
                                                                   id="quantity_` + item.productId + `"
                                                                   class="input-text text"
                                                                   step="1"
                                                                   min="0"
                                                                   max="9999"
                                                                   name="cart[a96b65a721e561e1e3de768ac819ffbb][qty]"
                                                                   value="`+ item.quantity + `"
                                                                   title="SL"
                                                                   size="4"
                                                                   inputmode="numeric" />
                                                            <input type="button" data-id="` + item.productId + `" value="+" class="plus button is-form qty-increase-cart">
                                                        </div>
                                                    </td>

                                                    <td class="product-subtotal" data-title="Tạm tính">
                                                        <span class="woocommerce-Price-amount amount">` + numberWithCommas(amount) + `&nbsp;<span class="woocommerce-Price-currencySymbol">&#8363;</span></span>
                                                    </td>
                                                </tr>

`;
                    total += amount;
                });
                $('.ListCart').html(html);
                $('.lbl_number_of_items').text(res.length);
                $('.lbl_total').text(numberWithCommas(total)+' đ');
                $('.lbl_number_items_header').text(res.length);
            }
        });
    }

    function updateCart(id, quantity) {
        $.ajax({
            type: "POST",
            url: '/Cart/UpdateCart',
            data: {
                id: id,
                quantity: quantity
            },
            success: function (res) {
                $('#lbl_number_items_header').text(res.length);
                loadData();
            },
            error: function (err) {
                toastr.error('Cập nhật giỏ hàng không thành công', 'Thất bại')
            }
        });
    }


    function regsiterEvents() {
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault();
            const id = $(this).data('id');
            var quantity = 1;
            var qty_el = $("#input-quantity").val();
            var qty = parseInt(qty_el);
            if (!isNaN(qty) && qty >= 1) {
                quantity = qty;
            }
            $.ajax({
                type: "POST",
                url: '/Cart/AddToCart',
                data: {
                    id: id,
                    quantity: quantity
                },
                success: function () {
                    toastr.success('Thêm giỏ hàng thành công', 'Thành công')
                    loadData();
                },
                error: function () {
                    toastr.error('Thêm giỏ hàng không thành công', 'Thất bại')
                }
            });
        });

        $('body').on('click', '.order-now', function (e) {
            e.preventDefault();
            var model = {
                ProductId: $("#producId").val(),
                Quantity: parseInt($("#input-quantity2").val()),
                OrderName: $("#customer-name").val(),
                OrderAddress: $("#customer-address").val(),
                OrderEmail: $("#customer-email").val(),
                OrderPhone: $("#customer-phone").val(),
                OrderNote: $("#customer-note").val()
            }
            $.ajax({
                type: "POST",
                url: '/Cart/OrderNow',
                data: {
                    order:model
                },
                success: function () {
                    toastr.success('Đặt hàng thành công', 'Thành công')
                    loadData();
                },
                error: function () {
                    toastr.error('Đặt hàng không thành công', 'Thất bại')
                }
            });
        });

        $('body').on('click', '.qty-increase-product', function () {
            var qty_el = $("#input-quantity").val();
            var price = Number($("#price").val());
            var qty = parseInt(qty_el);
            if (!isNaN(qty) && !isNaN(price)) {
                qty++;
                var subTotal = price * qty;
                $(".sub-total").text(numberWithCommas(subTotal));  
                $("#input-quantity").val(qty);
            }
        });

        $('body').on('click', '.qty-decrease-product', function () {
            var qty_el = $("#input-quantity").val();
            var price = Number($("#price").val());
            var qty = parseInt(qty_el);
            if (!isNaN(qty) && !isNaN(price) && qty > 1) {
                qty--;
                var subTotal = price * qty;
                $(".sub-total").text(numberWithCommas(subTotal));
                $("#input-quantity").val(qty);
            }
        });
        // cart
        $('body').on('click', '.removeItem', function () {
            const id = $(this).data('id');
            updateCart(id, 0);
        });

        $('body').on('click', '.updateItem', function () {
            setTimeout(() => {
                const id = $(this).data('id');
                const quantity = parseInt($('#quantity_' + id).val());
                updateCart(id, quantity);
            }, 500);        
        });

        $('body').on('click', '.qty-increase-cart', function () {
            const id = $(this).data('id');
            var qty_el = $("#quantity_" + id).val();
            var qty = parseInt(qty_el);
            if (!isNaN(qty)) {
                qty++;
                updateCart(id, qty);
            }
            $("#quantity_" + id).val(qty);
        });

        $('body').on('click', '.qty-decrease-cart', function () {
            const id = $(this).data('id');
            var qty_el = $("#quantity_" + id).val();
            var qty = parseInt(qty_el);
            if (!isNaN(qty) && qty > 1) {
                qty--;
                updateCart(id, qty);
            }
            $("#quantity_" + id).val(qty);
        });
    }
}

function numberWithCommas(x) {
    if (x === null || x === 0) {
        return 'Liên hệ';
    }
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}