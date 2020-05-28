<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="sale-order-search">

    <?php $form = ActiveForm::begin([
        'action' => ['index'],
        'method' => 'get',
    ]); ?>

    <?= $form->field($model, 'id') ?>

    <?= $form->field($model, 'campaign_id') ?>

    <?= $form->field($model, 'source_id') ?>

    <?= $form->field($model, 'medium_id') ?>

    <?= $form->field($model, 'message_main_attachment_id') ?>

    <?php // echo $form->field($model, 'access_token') ?>

    <?php // echo $form->field($model, 'name') ?>

    <?php // echo $form->field($model, 'origin') ?>

    <?php // echo $form->field($model, 'client_order_ref') ?>

    <?php // echo $form->field($model, 'reference') ?>

    <?php // echo $form->field($model, 'state') ?>

    <?php // echo $form->field($model, 'date_order') ?>

    <?php // echo $form->field($model, 'validity_date') ?>

    <?php // echo $form->field($model, 'require_signature') ?>

    <?php // echo $form->field($model, 'require_payment') ?>

    <?php // echo $form->field($model, 'create_date') ?>

    <?php // echo $form->field($model, 'user_id') ?>

    <?php // echo $form->field($model, 'partner_id') ?>

    <?php // echo $form->field($model, 'partner_invoice_id') ?>

    <?php // echo $form->field($model, 'partner_shipping_id') ?>

    <?php // echo $form->field($model, 'pricelist_id') ?>

    <?php // echo $form->field($model, 'analytic_account_id') ?>

    <?php // echo $form->field($model, 'invoice_status') ?>

    <?php // echo $form->field($model, 'note') ?>

    <?php // echo $form->field($model, 'amount_untaxed') ?>

    <?php // echo $form->field($model, 'amount_tax') ?>

    <?php // echo $form->field($model, 'amount_total') ?>

    <?php // echo $form->field($model, 'currency_rate') ?>

    <?php // echo $form->field($model, 'payment_term_id') ?>

    <?php // echo $form->field($model, 'fiscal_position_id') ?>

    <?php // echo $form->field($model, 'company_id') ?>

    <?php // echo $form->field($model, 'team_id') ?>

    <?php // echo $form->field($model, 'signed_by') ?>

    <?php // echo $form->field($model, 'signed_on') ?>

    <?php // echo $form->field($model, 'commitment_date') ?>

    <?php // echo $form->field($model, 'create_uid') ?>

    <?php // echo $form->field($model, 'write_uid') ?>

    <?php // echo $form->field($model, 'write_date') ?>

    <?php // echo $form->field($model, 'sale_order_template_id') ?>

    <?php // echo $form->field($model, 'incoterm') ?>

    <?php // echo $form->field($model, 'picking_policy') ?>

    <?php // echo $form->field($model, 'warehouse_id') ?>

    <?php // echo $form->field($model, 'procurement_group_id') ?>

    <?php // echo $form->field($model, 'effective_date') ?>

    <?php // echo $form->field($model, 'opportunity_id') ?>

    <?php // echo $form->field($model, 'cart_recovery_email_sent') ?>

    <?php // echo $form->field($model, 'website_id') ?>

    <?php // echo $form->field($model, 'warning_stock') ?>

    <?php // echo $form->field($model, 'trial539') ?>

    <div class="form-group">
        <?= Html::submitButton('Search', ['class' => 'btn btn-primary']) ?>
        <?= Html::resetButton('Reset', ['class' => 'btn btn-outline-secondary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
