<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="sale-order-line-search">

    <?php $form = ActiveForm::begin([
        'action' => ['index'],
        'method' => 'get',
    ]); ?>

    <?= $form->field($model, 'id') ?>

    <?= $form->field($model, 'order_id') ?>

    <?= $form->field($model, 'name') ?>

    <?= $form->field($model, 'sequence') ?>

    <?= $form->field($model, 'invoice_status') ?>

    <?php // echo $form->field($model, 'price_unit') ?>

    <?php // echo $form->field($model, 'price_subtotal') ?>

    <?php // echo $form->field($model, 'price_tax') ?>

    <?php // echo $form->field($model, 'price_total') ?>

    <?php // echo $form->field($model, 'price_reduce') ?>

    <?php // echo $form->field($model, 'price_reduce_taxinc') ?>

    <?php // echo $form->field($model, 'price_reduce_taxexcl') ?>

    <?php // echo $form->field($model, 'discount') ?>

    <?php // echo $form->field($model, 'product_id') ?>

    <?php // echo $form->field($model, 'product_uom_qty') ?>

    <?php // echo $form->field($model, 'product_uom') ?>

    <?php // echo $form->field($model, 'qty_delivered_method') ?>

    <?php // echo $form->field($model, 'qty_delivered') ?>

    <?php // echo $form->field($model, 'qty_delivered_manual') ?>

    <?php // echo $form->field($model, 'qty_to_invoice') ?>

    <?php // echo $form->field($model, 'qty_invoiced') ?>

    <?php // echo $form->field($model, 'untaxed_amount_invoiced') ?>

    <?php // echo $form->field($model, 'untaxed_amount_to_invoice') ?>

    <?php // echo $form->field($model, 'salesman_id') ?>

    <?php // echo $form->field($model, 'currency_id') ?>

    <?php // echo $form->field($model, 'company_id') ?>

    <?php // echo $form->field($model, 'order_partner_id') ?>

    <?php // echo $form->field($model, 'is_expense') ?>

    <?php // echo $form->field($model, 'is_downpayment') ?>

    <?php // echo $form->field($model, 'state') ?>

    <?php // echo $form->field($model, 'customer_lead') ?>

    <?php // echo $form->field($model, 'display_type') ?>

    <?php // echo $form->field($model, 'create_uid') ?>

    <?php // echo $form->field($model, 'create_date') ?>

    <?php // echo $form->field($model, 'write_uid') ?>

    <?php // echo $form->field($model, 'write_date') ?>

    <?php // echo $form->field($model, 'product_packaging') ?>

    <?php // echo $form->field($model, 'route_id') ?>

    <?php // echo $form->field($model, 'linked_line_id') ?>

    <?php // echo $form->field($model, 'warning_stock') ?>

    <?php // echo $form->field($model, 'trial555') ?>

    <div class="form-group">
        <?= Html::submitButton('Search', ['class' => 'btn btn-primary']) ?>
        <?= Html::resetButton('Reset', ['class' => 'btn btn-outline-secondary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
