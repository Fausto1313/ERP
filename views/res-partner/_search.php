<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

?>

<div class="res-partner-search">

    <?php $form = ActiveForm::begin([
        'action' => ['index'],
        'method' => 'get',
    ]); ?>

    <?= $form->field($model, 'id') ?>

    <?= $form->field($model, 'name') ?>

    <?= $form->field($model, 'company_id') ?>

    <?= $form->field($model, 'create_date') ?>

   

    <?php // echo $form->field($model, 'date') ?>

    <?php // echo $form->field($model, 'title') ?>

    <?php // echo $form->field($model, 'parent_id') ?>

    <?php // echo $form->field($model, 'ref') ?>

    <?php // echo $form->field($model, 'lang') ?>

    <?php // echo $form->field($model, 'tz') ?>

    <?php // echo $form->field($model, 'user_id') ?>

    <?php // echo $form->field($model, 'vat') ?>

    <?php // echo $form->field($model, 'website') ?>

    <?php // echo $form->field($model, 'comment') ?>

    <?php // echo $form->field($model, 'credit_limit') ?>

    <?php // echo $form->field($model, 'active') ?>

    <?php // echo $form->field($model, 'employee') ?>

    <?php // echo $form->field($model, 'function') ?>

    <?php // echo $form->field($model, 'type') ?>

    <?php // echo $form->field($model, 'street') ?>

    <?php // echo $form->field($model, 'street2') ?>

    <?php // echo $form->field($model, 'zip') ?>

    <?php // echo $form->field($model, 'city') ?>

    <?php // echo $form->field($model, 'state_id') ?>

    <?php // echo $form->field($model, 'country_id') ?>

    <?php // echo $form->field($model, 'partner_latitude') ?>

    <?php // echo $form->field($model, 'partner_longitude') ?>

    <?php // echo $form->field($model, 'email') ?>

    <?php // echo $form->field($model, 'phone') ?>

    <?php // echo $form->field($model, 'mobile') ?>

    <?php // echo $form->field($model, 'is_company') ?>

    <?php // echo $form->field($model, 'industry_id') ?>

    <?php // echo $form->field($model, 'color') ?>

    <?php // echo $form->field($model, 'partner_share') ?>

    <?php // echo $form->field($model, 'commercial_partner_id') ?>

    <?php // echo $form->field($model, 'commercial_company_name') ?>

    <?php // echo $form->field($model, 'company_name') ?>

    <?php // echo $form->field($model, 'create_uid') ?>

    <?php // echo $form->field($model, 'write_uid') ?>

    <?php // echo $form->field($model, 'write_date') ?>

    <?php // echo $form->field($model, 'message_main_attachment_id') ?>

    <?php // echo $form->field($model, 'email_normalized') ?>

    <?php // echo $form->field($model, 'message_bounce') ?>

    <?php // echo $form->field($model, 'signup_token') ?>

    <?php // echo $form->field($model, 'signup_type') ?>

    <?php // echo $form->field($model, 'signup_expiration') ?>

    <?php // echo $form->field($model, 'partner_gid') ?>

    <?php // echo $form->field($model, 'additional_info') ?>

    <?php // echo $form->field($model, 'phone_sanitized') ?>

    <?php // echo $form->field($model, 'website_id') ?>

    <?php // echo $form->field($model, 'is_published') ?>

    <?php // echo $form->field($model, 'calendar_last_notif_ack') ?>

    <?php // echo $form->field($model, 'team_id') ?>

    <?php // echo $form->field($model, 'picking_warn') ?>

    <?php // echo $form->field($model, 'picking_warn_msg') ?>

    <?php // echo $form->field($model, 'debit_limit') ?>

    <?php // echo $form->field($model, 'last_time_entries_checked') ?>

    <?php // echo $form->field($model, 'invoice_warn') ?>

    <?php // echo $form->field($model, 'invoice_warn_msg') ?>

    <?php // echo $form->field($model, 'supplier_rank') ?>

    <?php // echo $form->field($model, 'customer_rank') ?>

    <?php // echo $form->field($model, 'sale_warn') ?>

    <?php // echo $form->field($model, 'sale_warn_msg') ?>

    <?php // echo $form->field($model, 'purchase_warn') ?>

    <?php // echo $form->field($model, 'purchase_warn_msg') ?>

    <?php // echo $form->field($model, 'website_meta_title') ?>

    <?php // echo $form->field($model, 'website_meta_description') ?>

    <?php // echo $form->field($model, 'website_meta_keywords') ?>

    <?php // echo $form->field($model, 'website_meta_og_img') ?>

    <?php // echo $form->field($model, 'website_description') ?>

    <?php // echo $form->field($model, 'website_short_description') ?>

    <?php // echo $form->field($model, 'customer') ?>

    <?php // echo $form->field($model, 'trial496') ?>

    <div class="form-group">
        <?= Html::submitButton('Search', ['class' => 'btn btn-primary']) ?>
        <?= Html::resetButton('Reset', ['class' => 'btn btn-outline-secondary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
