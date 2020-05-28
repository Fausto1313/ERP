<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ResCompany;

class ResCompanySearch extends ResCompany
{
    public function rules()
    {
        return [
            [['id', 'partner_id', 'currency_id', 'sequence', 'parent_id', 'paperformat_id', 'external_report_layout_id', 'create_uid', 'write_uid', 'partner_gid', 'snailmail_color', 'snailmail_cover', 'snailmail_duplex', 'resource_calendar_id', 'nomenclature_id', 'internal_transit_location_id', 'stock_move_email_validation', 'stock_mail_confirmation_template_id', 'stock_move_sms_validation', 'stock_sms_confirmation_template_id', 'has_received_warning_stock_sms', 'fiscalyear_last_day', 'transfer_account_id', 'expects_chart_of_accounts', 'chart_template_id', 'default_cash_difference_income_account_id', 'default_cash_difference_expense_account_id', 'account_sale_tax_id', 'account_purchase_tax_id', 'tax_cash_basis_journal_id', 'currency_exchange_journal_id', 'anglo_saxon_accounting', 'property_stock_account_input_categ_id', 'property_stock_account_output_categ_id', 'property_stock_valuation_account_id', 'tax_exigibility', 'incoterm_id', 'qr_code', 'invoice_is_email', 'invoice_is_print', 'account_opening_move_id', 'account_default_pos_receivable_account_id', 'expense_accrual_account_id', 'revenue_accrual_account_id', 'accrual_default_journal_id', 'invoice_is_snailmail', 'vat_check_vies', 'portal_confirmation_sign', 'portal_confirmation_pay', 'quotation_validity_days', 'hr_presence_control_email_amount'], 'integer'],
            [['name', 'create_date', 'report_header', 'report_footer', 'logo_web', 'account_no', 'email', 'phone', 'company_registry', 'base_onboarding_company_state', 'font', 'primary_color', 'secondary_color', 'write_date', 'social_twitter', 'social_facebook', 'social_github', 'social_linkedin', 'social_youtube', 'social_instagram', 'fiscalyear_last_month', 'period_lock_date', 'fiscalyear_lock_date', 'tax_lock_date', 'bank_account_code_prefix', 'cash_account_code_prefix', 'transfer_account_code_prefix', 'tax_calculation_rounding_method', 'account_bank_reconciliation_start', 'account_setup_bank_data_state', 'account_setup_fy_data_state', 'account_setup_coa_state', 'account_onboarding_invoice_layout_state', 'account_onboarding_sample_invoice_state', 'account_onboarding_sale_tax_state', 'account_invoice_onboarding_state', 'account_dashboard_onboarding_state', 'invoice_terms', 'payment_acquirer_onboarding_state', 'payment_onboarding_payment_method', 'sale_quotation_onboarding_state', 'sale_onboarding_order_confirmation_state', 'sale_onboarding_sample_quotation_state', 'sale_onboarding_payment_method', 'website_sale_onboarding_payment_acquirer_state', 'po_lock', 'po_double_validation', 'hr_presence_control_ip_list', 'trial415'], 'safe'],
            [['manufacturing_lead', 'security_lead', 'po_lead', 'po_double_validation_amount'], 'number'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = ResCompany::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'partner_id' => $this->partner_id,
            'currency_id' => $this->currency_id,
            'sequence' => $this->sequence,
            'create_date' => $this->create_date,
            'parent_id' => $this->parent_id,
            'paperformat_id' => $this->paperformat_id,
            'external_report_layout_id' => $this->external_report_layout_id,
            'create_uid' => $this->create_uid,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
            'partner_gid' => $this->partner_gid,
            'snailmail_color' => $this->snailmail_color,
            'snailmail_cover' => $this->snailmail_cover,
            'snailmail_duplex' => $this->snailmail_duplex,
            'resource_calendar_id' => $this->resource_calendar_id,
            'nomenclature_id' => $this->nomenclature_id,
            'internal_transit_location_id' => $this->internal_transit_location_id,
            'stock_move_email_validation' => $this->stock_move_email_validation,
            'stock_mail_confirmation_template_id' => $this->stock_mail_confirmation_template_id,
            'stock_move_sms_validation' => $this->stock_move_sms_validation,
            'stock_sms_confirmation_template_id' => $this->stock_sms_confirmation_template_id,
            'has_received_warning_stock_sms' => $this->has_received_warning_stock_sms,
            'fiscalyear_last_day' => $this->fiscalyear_last_day,
            'period_lock_date' => $this->period_lock_date,
            'fiscalyear_lock_date' => $this->fiscalyear_lock_date,
            'tax_lock_date' => $this->tax_lock_date,
            'transfer_account_id' => $this->transfer_account_id,
            'expects_chart_of_accounts' => $this->expects_chart_of_accounts,
            'chart_template_id' => $this->chart_template_id,
            'default_cash_difference_income_account_id' => $this->default_cash_difference_income_account_id,
            'default_cash_difference_expense_account_id' => $this->default_cash_difference_expense_account_id,
            'account_sale_tax_id' => $this->account_sale_tax_id,
            'account_purchase_tax_id' => $this->account_purchase_tax_id,
            'tax_cash_basis_journal_id' => $this->tax_cash_basis_journal_id,
            'currency_exchange_journal_id' => $this->currency_exchange_journal_id,
            'anglo_saxon_accounting' => $this->anglo_saxon_accounting,
            'property_stock_account_input_categ_id' => $this->property_stock_account_input_categ_id,
            'property_stock_account_output_categ_id' => $this->property_stock_account_output_categ_id,
            'property_stock_valuation_account_id' => $this->property_stock_valuation_account_id,
            'tax_exigibility' => $this->tax_exigibility,
            'account_bank_reconciliation_start' => $this->account_bank_reconciliation_start,
            'incoterm_id' => $this->incoterm_id,
            'qr_code' => $this->qr_code,
            'invoice_is_email' => $this->invoice_is_email,
            'invoice_is_print' => $this->invoice_is_print,
            'account_opening_move_id' => $this->account_opening_move_id,
            'account_default_pos_receivable_account_id' => $this->account_default_pos_receivable_account_id,
            'expense_accrual_account_id' => $this->expense_accrual_account_id,
            'revenue_accrual_account_id' => $this->revenue_accrual_account_id,
            'accrual_default_journal_id' => $this->accrual_default_journal_id,
            'invoice_is_snailmail' => $this->invoice_is_snailmail,
            'vat_check_vies' => $this->vat_check_vies,
            'manufacturing_lead' => $this->manufacturing_lead,
            'portal_confirmation_sign' => $this->portal_confirmation_sign,
            'portal_confirmation_pay' => $this->portal_confirmation_pay,
            'quotation_validity_days' => $this->quotation_validity_days,
            'security_lead' => $this->security_lead,
            'po_lead' => $this->po_lead,
            'po_double_validation_amount' => $this->po_double_validation_amount,
            'hr_presence_control_email_amount' => $this->hr_presence_control_email_amount,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'report_header', $this->report_header])
            ->andFilterWhere(['like', 'report_footer', $this->report_footer])
            ->andFilterWhere(['like', 'logo_web', $this->logo_web])
            ->andFilterWhere(['like', 'account_no', $this->account_no])
            ->andFilterWhere(['like', 'email', $this->email])
            ->andFilterWhere(['like', 'phone', $this->phone])
            ->andFilterWhere(['like', 'company_registry', $this->company_registry])
            ->andFilterWhere(['like', 'base_onboarding_company_state', $this->base_onboarding_company_state])
            ->andFilterWhere(['like', 'font', $this->font])
            ->andFilterWhere(['like', 'primary_color', $this->primary_color])
            ->andFilterWhere(['like', 'secondary_color', $this->secondary_color])
            ->andFilterWhere(['like', 'social_twitter', $this->social_twitter])
            ->andFilterWhere(['like', 'social_facebook', $this->social_facebook])
            ->andFilterWhere(['like', 'social_github', $this->social_github])
            ->andFilterWhere(['like', 'social_linkedin', $this->social_linkedin])
            ->andFilterWhere(['like', 'social_youtube', $this->social_youtube])
            ->andFilterWhere(['like', 'social_instagram', $this->social_instagram])
            ->andFilterWhere(['like', 'fiscalyear_last_month', $this->fiscalyear_last_month])
            ->andFilterWhere(['like', 'bank_account_code_prefix', $this->bank_account_code_prefix])
            ->andFilterWhere(['like', 'cash_account_code_prefix', $this->cash_account_code_prefix])
            ->andFilterWhere(['like', 'transfer_account_code_prefix', $this->transfer_account_code_prefix])
            ->andFilterWhere(['like', 'tax_calculation_rounding_method', $this->tax_calculation_rounding_method])
            ->andFilterWhere(['like', 'account_setup_bank_data_state', $this->account_setup_bank_data_state])
            ->andFilterWhere(['like', 'account_setup_fy_data_state', $this->account_setup_fy_data_state])
            ->andFilterWhere(['like', 'account_setup_coa_state', $this->account_setup_coa_state])
            ->andFilterWhere(['like', 'account_onboarding_invoice_layout_state', $this->account_onboarding_invoice_layout_state])
            ->andFilterWhere(['like', 'account_onboarding_sample_invoice_state', $this->account_onboarding_sample_invoice_state])
            ->andFilterWhere(['like', 'account_onboarding_sale_tax_state', $this->account_onboarding_sale_tax_state])
            ->andFilterWhere(['like', 'account_invoice_onboarding_state', $this->account_invoice_onboarding_state])
            ->andFilterWhere(['like', 'account_dashboard_onboarding_state', $this->account_dashboard_onboarding_state])
            ->andFilterWhere(['like', 'invoice_terms', $this->invoice_terms])
            ->andFilterWhere(['like', 'payment_acquirer_onboarding_state', $this->payment_acquirer_onboarding_state])
            ->andFilterWhere(['like', 'payment_onboarding_payment_method', $this->payment_onboarding_payment_method])
            ->andFilterWhere(['like', 'sale_quotation_onboarding_state', $this->sale_quotation_onboarding_state])
            ->andFilterWhere(['like', 'sale_onboarding_order_confirmation_state', $this->sale_onboarding_order_confirmation_state])
            ->andFilterWhere(['like', 'sale_onboarding_sample_quotation_state', $this->sale_onboarding_sample_quotation_state])
            ->andFilterWhere(['like', 'sale_onboarding_payment_method', $this->sale_onboarding_payment_method])
            ->andFilterWhere(['like', 'website_sale_onboarding_payment_acquirer_state', $this->website_sale_onboarding_payment_acquirer_state])
            ->andFilterWhere(['like', 'po_lock', $this->po_lock])
            ->andFilterWhere(['like', 'po_double_validation', $this->po_double_validation])
            ->andFilterWhere(['like', 'hr_presence_control_ip_list', $this->hr_presence_control_ip_list])
            ->andFilterWhere(['like', 'trial415', $this->trial415]);

        return $dataProvider;
    }
}
