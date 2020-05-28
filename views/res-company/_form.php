<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
?>

<div class="res-company-form">

    <?php $form = ActiveForm::begin(); ?>

    <?= $form->field($model, 'name')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'partner_id')->textInput() ?>

    <?= $form->field($model, 'currency_id')->textInput() ?>

    <?= $form->field($model, 'sequence')->textInput() ?>

    <?= $form->field($model, 'create_date')->textInput() ?>

    <?= $form->field($model, 'parent_id')->textInput() ?>

    <?= $form->field($model, 'report_header')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'report_footer')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'logo_web')->textInput() ?>

    <?= $form->field($model, 'account_no')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'email')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'phone')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'company_registry')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'paperformat_id')->textInput() ?>

    <?= $form->field($model, 'external_report_layout_id')->textInput() ?>

    <?= $form->field($model, 'base_onboarding_company_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'font')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'primary_color')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'secondary_color')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'create_uid')->textInput() ?>

    <?= $form->field($model, 'write_uid')->textInput() ?>

    <?= $form->field($model, 'write_date')->textInput() ?>

    <?= $form->field($model, 'social_twitter')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'social_facebook')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'social_github')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'social_linkedin')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'social_youtube')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'social_instagram')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'partner_gid')->textInput() ?>

    <?= $form->field($model, 'snailmail_color')->textInput() ?>

    <?= $form->field($model, 'snailmail_cover')->textInput() ?>

    <?= $form->field($model, 'snailmail_duplex')->textInput() ?>

    <?= $form->field($model, 'resource_calendar_id')->textInput() ?>

    <?= $form->field($model, 'nomenclature_id')->textInput() ?>

    <?= $form->field($model, 'internal_transit_location_id')->textInput() ?>

    <?= $form->field($model, 'stock_move_email_validation')->textInput() ?>

    <?= $form->field($model, 'stock_mail_confirmation_template_id')->textInput() ?>

    <?= $form->field($model, 'stock_move_sms_validation')->textInput() ?>

    <?= $form->field($model, 'stock_sms_confirmation_template_id')->textInput() ?>

    <?= $form->field($model, 'has_received_warning_stock_sms')->textInput() ?>

    <?= $form->field($model, 'fiscalyear_last_day')->textInput() ?>

    <?= $form->field($model, 'fiscalyear_last_month')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'period_lock_date')->textInput() ?>

    <?= $form->field($model, 'fiscalyear_lock_date')->textInput() ?>

    <?= $form->field($model, 'tax_lock_date')->textInput() ?>

    <?= $form->field($model, 'transfer_account_id')->textInput() ?>

    <?= $form->field($model, 'expects_chart_of_accounts')->textInput() ?>

    <?= $form->field($model, 'chart_template_id')->textInput() ?>

    <?= $form->field($model, 'bank_account_code_prefix')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'cash_account_code_prefix')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'default_cash_difference_income_account_id')->textInput() ?>

    <?= $form->field($model, 'default_cash_difference_expense_account_id')->textInput() ?>

    <?= $form->field($model, 'transfer_account_code_prefix')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'account_sale_tax_id')->textInput() ?>

    <?= $form->field($model, 'account_purchase_tax_id')->textInput() ?>

    <?= $form->field($model, 'tax_cash_basis_journal_id')->textInput() ?>

    <?= $form->field($model, 'tax_calculation_rounding_method')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'currency_exchange_journal_id')->textInput() ?>

    <?= $form->field($model, 'anglo_saxon_accounting')->textInput() ?>

    <?= $form->field($model, 'property_stock_account_input_categ_id')->textInput() ?>

    <?= $form->field($model, 'property_stock_account_output_categ_id')->textInput() ?>

    <?= $form->field($model, 'property_stock_valuation_account_id')->textInput() ?>

    <?= $form->field($model, 'tax_exigibility')->textInput() ?>

    <?= $form->field($model, 'account_bank_reconciliation_start')->textInput() ?>

    <?= $form->field($model, 'incoterm_id')->textInput() ?>

    <?= $form->field($model, 'qr_code')->textInput() ?>

    <?= $form->field($model, 'invoice_is_email')->textInput() ?>

    <?= $form->field($model, 'invoice_is_print')->textInput() ?>

    <?= $form->field($model, 'account_opening_move_id')->textInput() ?>

    <?= $form->field($model, 'account_setup_bank_data_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'account_setup_fy_data_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'account_setup_coa_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'account_onboarding_invoice_layout_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'account_onboarding_sample_invoice_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'account_onboarding_sale_tax_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'account_invoice_onboarding_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'account_dashboard_onboarding_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'invoice_terms')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'account_default_pos_receivable_account_id')->textInput() ?>

    <?= $form->field($model, 'expense_accrual_account_id')->textInput() ?>

    <?= $form->field($model, 'revenue_accrual_account_id')->textInput() ?>

    <?= $form->field($model, 'accrual_default_journal_id')->textInput() ?>

    <?= $form->field($model, 'payment_acquirer_onboarding_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'payment_onboarding_payment_method')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'invoice_is_snailmail')->textInput() ?>

    <?= $form->field($model, 'vat_check_vies')->textInput() ?>

    <?= $form->field($model, 'manufacturing_lead')->textInput() ?>

    <?= $form->field($model, 'portal_confirmation_sign')->textInput() ?>

    <?= $form->field($model, 'portal_confirmation_pay')->textInput() ?>

    <?= $form->field($model, 'quotation_validity_days')->textInput() ?>

    <?= $form->field($model, 'sale_quotation_onboarding_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'sale_onboarding_order_confirmation_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'sale_onboarding_sample_quotation_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'sale_onboarding_payment_method')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'security_lead')->textInput() ?>

    <?= $form->field($model, 'website_sale_onboarding_payment_acquirer_state')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'po_lead')->textInput() ?>

    <?= $form->field($model, 'po_lock')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'po_double_validation')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'po_double_validation_amount')->textInput() ?>

    <?= $form->field($model, 'hr_presence_control_email_amount')->textInput() ?>

    <?= $form->field($model, 'hr_presence_control_ip_list')->textarea(['rows' => 6]) ?>

    <?= $form->field($model, 'trial415')->textInput(['maxlength' => true]) ?>

    <div class="form-group">
        <?= Html::submitButton('Save', ['class' => 'btn btn-success']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
