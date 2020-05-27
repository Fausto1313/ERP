<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;

/* @var $this yii\web\View */
/* @var $model app\models\ResPartner */
/* @var $form yii\widgets\ActiveForm */
?>

<div class="res-partner-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'name')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'company_id')->textInput() ?>

    <?= $form->field($model, 'create_date')->textInput() ?>

    <?= $form->field($model, 'display_name')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'date')->textInput() ?>

    <?= $form->field($model, 'title')->textInput() ?>

    <?= $form->field($model, 'parent_id')->textInput() ?>

    <?= $form->field($model, 'ref')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'lang')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'tz')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'user_id')->textInput() ?>

    <?= $form->field($model, 'vat')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'comment')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'credit_limit')->textInput() ?>

    <?= $form->field($model, 'active')->textInput() ?>

    <?= $form->field($model, 'employee')->textInput() ?>

    <?= $form->field($model, 'function')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'type')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'street')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'street2')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'zip')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'city')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'state_id')->textInput() ?>

    <?= $form->field($model, 'country_id')->textInput() ?>

    <?= $form->field($model, 'partner_latitude')->textInput() ?>

    <?= $form->field($model, 'partner_longitude')->textInput() ?>

    <?= $form->field($model, 'email')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'phone')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'mobile')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'is_company')->textInput() ?>

    <?= $form->field($model, 'industry_id')->textInput() ?>

    <?= $form->field($model, 'color')->textInput() ?>

    <?= $form->field($model, 'partner_share')->textInput() ?>

    <?= $form->field($model, 'commercial_partner_id')->textInput() ?>

    <?= $form->field($model, 'commercial_company_name')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'company_name')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'create_uid')->textInput() ?>

    <?= $form->field($model, 'write_uid')->textInput() ?>

    <?= $form->field($model, 'write_date')->textInput() ?>

    <?= $form->field($model, 'message_main_attachment_id')->textInput() ?>

    <?= $form->field($model, 'email_normalized')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'message_bounce')->textInput() ?>

    <?= $form->field($model, 'signup_token')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'signup_type')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'signup_expiration')->textInput() ?>

    <?= $form->field($model, 'partner_gid')->textInput() ?>

    <?= $form->field($model, 'additional_info')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'phone_sanitized')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website_id')->textInput() ?>

    <?= $form->field($model, 'is_published')->textInput() ?>

    <?= $form->field($model, 'calendar_last_notif_ack')->textInput() ?>

    <?= $form->field($model, 'team_id')->textInput() ?>

    <?= $form->field($model, 'picking_warn')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'picking_warn_msg')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'debit_limit')->textInput() ?>

    <?= $form->field($model, 'last_time_entries_checked')->textInput() ?>

    <?= $form->field($model, 'invoice_warn')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'invoice_warn_msg')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'supplier_rank')->textInput() ?>

    <?= $form->field($model, 'customer_rank')->textInput() ?>

    <?= $form->field($model, 'sale_warn')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'sale_warn_msg')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'purchase_warn')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'purchase_warn_msg')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website_meta_title')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website_meta_description')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website_meta_keywords')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website_meta_og_img')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website_description')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'website_short_description')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'customer')->textInput() ?>

    <?= $form->field($model, 'trial496')->textInput(['maxlength' => true]) ?>

    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
