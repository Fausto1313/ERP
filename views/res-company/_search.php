<?php

use yii\helpers\Html;
use yii\widgets\ActiveForm;
?>

<div class="res-company-search">

    <?php $form = ActiveForm::begin([
        'action' => ['index'],
        'method' => 'get',
    ]); ?>

    <?= $form->field($model, 'id') ?>

    <?= $form->field($model, 'name') ?>

    <?= $form->field($model, 'partner_id') ?>

    <?= $form->field($model, 'currency_id') ?>

    <?= $form->field($model, 'sequence') ?>

    <?php // echo $form->field($model, 'create_date') ?>

    <?php // echo $form->field($model, 'parent_id') ?>

    <?php // echo $form->field($model, 'report_header') ?>

    <?php // echo $form->field($model, 'report_footer') ?>

    <?php // echo $form->field($model, 'logo_web') ?>

    <?php // echo $form->field($model, 'account_no') ?>

    <?php // echo $form->field($model, 'email') ?>

    <?php // echo $form->field($model, 'phone') ?>

    <?php // echo $form->field($model, 'company_registry') ?>

    <?php // echo $form->field($model, 'paperformat_id') ?>

    <?php // echo $form->field($model, 'external_report_layout_id') ?>

    <?php // echo $form->field($model, 'base_onboarding_company_state') ?>

    <?php // echo $form->field($model, 'font') ?>

    <?php // echo $form->field($model, 'primary_color') ?>

    <?php // echo $form->field($model, 'secondary_color') ?>

    <?php // echo $form->field($model, 'create_uid') ?>

    <?php // echo $form->field($model, 'write_uid') ?>

    <?php // echo $form->field($model, 'write_date') ?>

    <?php // echo $form->field($model, 'social_twitter') ?>

    <?php // echo $form->field($model, 'social_facebook') ?>

    <?php // echo $form->field($model, 'social_github') ?>

    <?php // echo $form->field($model, 'social_linkedin') ?>

    <?php // echo $form->field($model, 'social_youtube') ?>

    <?php // echo $form->field($model, 'social_instagram') ?>

    <?php // echo $form->field($model, 'partner_gid') ?>

    <?php // echo $form->field($model, 'snailmail_color') ?>

    <?php // echo $form->field($model, 'snailmail_cover') ?>

    <?php // echo $form->field($model, 'snailmail_duplex') ?>

    <?php // echo $form->field($model, 'resource_calendar_id') ?>

    <?php // echo $form->field($model, 'nomenclature_id') ?>

    <?php // echo $form->field($model, 'internal_transit_location_id') ?>

    <?php // echo $form->field($model, 'stock_move_email_validation') ?>

    <?php // echo $form->field($model, 'stock_mail_confirmation_template_id') ?>

    <?php // echo $form->field($model, 'stock_move_sms_validation') ?>

    <?php // echo $form->field($model, 'stock_sms_confirmation_template_id') ?>

    <?php // echo $form->field($model, 'has_received_warning_stock_sms') ?>

    <?php // echo $form->field($model, 'fiscalyear_last_day') ?>

    <?php // echo $form->field($model, 'fiscalyear_last_month') ?>

    <?php // echo $form->field($model, 'period_lock_date') ?>

    <?php // echo $form->field($model, 'fiscalyear_lock_date') ?>

    <?php // echo $form->field($model, 'tax_lock_date') ?>

    <?php // echo $form->field($model, 'transfer_account_id') ?>

    <?php // echo $form->field($model, 'expects_chart_of_accounts') ?>

    <?php // echo $form->field($model, 'chart_template_id') ?>

    <?php // echo $form->field($model, 'bank_account_code_prefix') ?>

    <?php // echo $form->field($model, 'cash_account_code_prefix') ?>

    <?php // echo $form->field($model, 'default_cash_difference_income_account_id') ?>

    <?php // echo $form->field($model, 'default_cash_difference_expense_account_id') ?>

    <?php // echo $form->field($model, 'transfer_account_code_prefix') ?>

    <?php // echo $form->field($model, 'account_sale_tax_id') ?>

    <?php // echo $form->field($model, 'account_purchase_tax_id') ?>

    <?php // echo $form->field($model, 'tax_cash_basis_journal_id') ?>

    <?php // echo $form->field($model, 'tax_calculation_rounding_method') ?>

    <?php // echo $form->field($model, 'currency_exchange_journal_id') ?>

    <?php // echo $form->field($model, 'anglo_saxon_accounting') ?>

    <?php // echo $form->field($model, 'property_stock_account_input_categ_id') ?>

    <?php // echo $form->field($model, 'property_stock_account_output_categ_id') ?>

    <?php // echo $form->field($model, 'property_stock_valuation_account_id') ?>

    <?php // echo $form->field($model, 'tax_exigibility') ?>

    <?php // echo $form->field($model, 'account_bank_reconciliation_start') ?>

    <?php // echo $form->field($model, 'incoterm_id') ?>

    <?php // echo $form->field($model, 'qr_code') ?>

    <?php // echo $form->field($model, 'invoice_is_email') ?>

    <?php // echo $form->field($model, 'invoice_is_print') ?>

    <?php // echo $form->field($model, 'account_opening_move_id') ?>

    <?php // echo $form->field($model, 'account_setup_bank_data_state') ?>

    <?php // echo $form->field($model, 'account_setup_fy_data_state') ?>

    <?php // echo $form->field($model, 'account_setup_coa_state') ?>

    <?php // echo $form->field($model, 'account_onboarding_invoice_layout_state') ?>

    <?php // echo $form->field($model, 'account_onboarding_sample_invoice_state') ?>

    <?php // echo $form->field($model, 'account_onboarding_sale_tax_state') ?>

    <?php // echo $form->field($model, 'account_invoice_onboarding_state') ?>

    <?php // echo $form->field($model, 'account_dashboard_onboarding_state') ?>

    <?php // echo $form->field($model, 'invoice_terms') ?>

    <?php // echo $form->field($model, 'account_default_pos_receivable_account_id') ?>

    <?php // echo $form->field($model, 'expense_accrual_account_id') ?>

    <?php // echo $form->field($model, 'revenue_accrual_account_id') ?>

    <?php // echo $form->field($model, 'accrual_default_journal_id') ?>

    <?php // echo $form->field($model, 'payment_acquirer_onboarding_state') ?>

    <?php // echo $form->field($model, 'payment_onboarding_payment_method') ?>

    <?php // echo $form->field($model, 'invoice_is_snailmail') ?>

    <?php // echo $form->field($model, 'vat_check_vies') ?>

    <?php // echo $form->field($model, 'manufacturing_lead') ?>

    <?php // echo $form->field($model, 'portal_confirmation_sign') ?>

    <?php // echo $form->field($model, 'portal_confirmation_pay') ?>

    <?php // echo $form->field($model, 'quotation_validity_days') ?>

    <?php // echo $form->field($model, 'sale_quotation_onboarding_state') ?>

    <?php // echo $form->field($model, 'sale_onboarding_order_confirmation_state') ?>

    <?php // echo $form->field($model, 'sale_onboarding_sample_quotation_state') ?>

    <?php // echo $form->field($model, 'sale_onboarding_payment_method') ?>

    <?php // echo $form->field($model, 'security_lead') ?>

    <?php // echo $form->field($model, 'website_sale_onboarding_payment_acquirer_state') ?>

    <?php // echo $form->field($model, 'po_lead') ?>

    <?php // echo $form->field($model, 'po_lock') ?>

    <?php // echo $form->field($model, 'po_double_validation') ?>

    <?php // echo $form->field($model, 'po_double_validation_amount') ?>

    <?php // echo $form->field($model, 'hr_presence_control_email_amount') ?>

    <?php // echo $form->field($model, 'hr_presence_control_ip_list') ?>

    <?php // echo $form->field($model, 'trial415') ?>

    <div class="form-group">
        <?= Html::submitButton('Search', ['class' => 'btn btn-primary']) ?>
        <?= Html::resetButton('Reset', ['class' => 'btn btn-outline-secondary']) ?>
    </div>

    <?php ActiveForm::end(); ?>

</div>
