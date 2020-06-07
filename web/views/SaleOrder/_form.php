<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="sale-order-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'campaign_id')->textInput() ?>

    <?= $form->field($model, 'source_id')->textInput() ?>

    <?= $form->field($model, 'medium_id')->textInput() ?>

    <?= $form->field($model, 'message_main_attachment_id')->textInput() ?>

    <?= $form->field($model, 'access_token')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'name')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'origin')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'client_order_ref')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'reference')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'date_order')->textInput() ?>

    <?= $form->field($model, 'validity_date')->textInput() ?>

    <?= $form->field($model, 'require_signature')->textInput() ?>

    <?= $form->field($model, 'require_payment')->textInput() ?>

    <?= $form->field($model, 'create_date')->textInput() ?>

    <?= $form->field($model, 'user_id')->textInput() ?>

    <?= $form->field($model, 'partner_id')->textInput() ?>

    <?= $form->field($model, 'partner_invoice_id')->textInput() ?>

    <?= $form->field($model, 'partner_shipping_id')->textInput() ?>

    <?= $form->field($model, 'pricelist_id')->textInput() ?>

    <?= $form->field($model, 'analytic_account_id')->textInput() ?>

    <?= $form->field($model, 'invoice_status')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'note')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'amount_untaxed')->textInput() ?>

    <?= $form->field($model, 'amount_tax')->textInput() ?>

    <?= $form->field($model, 'amount_total')->textInput() ?>

    <?= $form->field($model, 'currency_rate')->textInput() ?>

    <?= $form->field($model, 'payment_term_id')->textInput() ?>

    <?= $form->field($model, 'fiscal_position_id')->textInput() ?>

    <?= $form->field($model, 'company_id')->textInput() ?>

    <?= $form->field($model, 'team_id')->textInput() ?>

    <?= $form->field($model, 'signed_by')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'signed_on')->textInput() ?>

    <?= $form->field($model, 'commitment_date')->textInput() ?>

    <?= $form->field($model, 'create_uid')->textInput() ?>

    <?= $form->field($model, 'write_uid')->textInput() ?>

    <?= $form->field($model, 'write_date')->textInput() ?>

    <?= $form->field($model, 'sale_order_template_id')->textInput() ?>

    <?= $form->field($model, 'incoterm')->textInput() ?>

    <?= $form->field($model, 'picking_policy')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'warehouse_id')->textInput() ?>

    <?= $form->field($model, 'procurement_group_id')->textInput() ?>

    <?= $form->field($model, 'effective_date')->textInput() ?>

    <?= $form->field($model, 'opportunity_id')->textInput() ?>

    <?= $form->field($model, 'cart_recovery_email_sent')->textInput() ?>

    <?= $form->field($model, 'website_id')->textInput() ?>

    <?= $form->field($model, 'warning_stock')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'trial539')->textInput(['maxlength' => true]) ?>

    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
