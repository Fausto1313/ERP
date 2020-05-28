<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="sale-order-line-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'order_id')->textInput() ?>

    <?= $form->field($model, 'name')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'sequence')->textInput() ?>

    <?= $form->field($model, 'invoice_status')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'price_unit')->textInput() ?>

    <?= $form->field($model, 'price_subtotal')->textInput() ?>

    <?= $form->field($model, 'price_tax')->textInput() ?>

    <?= $form->field($model, 'price_total')->textInput() ?>

    <?= $form->field($model, 'price_reduce')->textInput() ?>

    <?= $form->field($model, 'price_reduce_taxinc')->textInput() ?>

    <?= $form->field($model, 'price_reduce_taxexcl')->textInput() ?>

    <?= $form->field($model, 'discount')->textInput() ?>

    <?= $form->field($model, 'product_id')->textInput() ?>

    <?= $form->field($model, 'product_uom_qty')->textInput() ?>

    <?= $form->field($model, 'product_uom')->textInput() ?>

    <?= $form->field($model, 'qty_delivered_method')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'qty_delivered')->textInput() ?>

    <?= $form->field($model, 'qty_delivered_manual')->textInput() ?>

    <?= $form->field($model, 'qty_to_invoice')->textInput() ?>

    <?= $form->field($model, 'qty_invoiced')->textInput() ?>

    <?= $form->field($model, 'untaxed_amount_invoiced')->textInput() ?>

    <?= $form->field($model, 'untaxed_amount_to_invoice')->textInput() ?>

    <?= $form->field($model, 'salesman_id')->textInput() ?>

    <?= $form->field($model, 'currency_id')->textInput() ?>

    <?= $form->field($model, 'company_id')->textInput() ?>

    <?= $form->field($model, 'order_partner_id')->textInput() ?>

    <?= $form->field($model, 'is_expense')->textInput() ?>

    <?= $form->field($model, 'is_downpayment')->textInput() ?>

    <?= $form->field($model, 'state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'customer_lead')->textInput() ?>

    <?= $form->field($model, 'display_type')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'create_uid')->textInput() ?>

    <?= $form->field($model, 'create_date')->textInput() ?>

    <?= $form->field($model, 'write_uid')->textInput() ?>

    <?= $form->field($model, 'write_date')->textInput() ?>

    <?= $form->field($model, 'product_packaging')->textInput() ?>

    <?= $form->field($model, 'route_id')->textInput() ?>

    <?= $form->field($model, 'linked_line_id')->textInput() ?>

    <?= $form->field($model, 'warning_stock')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'trial555')->textInput(['maxlength' => true]) ?>

    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
