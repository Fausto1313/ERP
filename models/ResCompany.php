<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "res_company".
 *
 * @property int $id TRIAL
 * @property string $name TRIAL
 * @property int $partner_id TRIAL
 * @property int $currency_id TRIAL
 * @property int|null $sequence TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $parent_id TRIAL
 * @property string|null $report_header TRIAL
 * @property string|null $report_footer TRIAL
 * @property resource|null $logo_web TRIAL
 * @property string|null $account_no TRIAL
 * @property string|null $email TRIAL
 * @property string|null $phone TRIAL
 * @property string|null $company_registry TRIAL
 * @property int|null $paperformat_id TRIAL
 * @property int|null $external_report_layout_id TRIAL
 * @property string|null $base_onboarding_company_state TRIAL
 * @property string|null $font TRIAL
 * @property string|null $primary_color TRIAL
 * @property string|null $secondary_color TRIAL
 * @property int|null $create_uid TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $social_twitter TRIAL
 * @property string|null $social_facebook TRIAL
 * @property string|null $social_github TRIAL
 * @property string|null $social_linkedin TRIAL
 * @property string|null $social_youtube TRIAL
 * @property string|null $social_instagram TRIAL
 * @property int|null $partner_gid TRIAL
 * @property int|null $snailmail_color TRIAL
 * @property int|null $snailmail_cover TRIAL
 * @property int|null $snailmail_duplex TRIAL
 * @property int|null $resource_calendar_id TRIAL
 * @property int|null $nomenclature_id TRIAL
 * @property int|null $internal_transit_location_id TRIAL
 * @property int|null $stock_move_email_validation TRIAL
 * @property int|null $stock_mail_confirmation_template_id TRIAL
 * @property int|null $stock_move_sms_validation TRIAL
 * @property int|null $stock_sms_confirmation_template_id TRIAL
 * @property int|null $has_received_warning_stock_sms TRIAL
 * @property int $fiscalyear_last_day TRIAL
 * @property string $fiscalyear_last_month TRIAL
 * @property string|null $period_lock_date TRIAL
 * @property string|null $fiscalyear_lock_date TRIAL
 * @property string|null $tax_lock_date TRIAL
 * @property int|null $transfer_account_id TRIAL
 * @property int|null $expects_chart_of_accounts TRIAL
 * @property int|null $chart_template_id TRIAL
 * @property string|null $bank_account_code_prefix TRIAL
 * @property string|null $cash_account_code_prefix TRIAL
 * @property int|null $default_cash_difference_income_account_id TRIAL
 * @property int|null $default_cash_difference_expense_account_id TRIAL
 * @property string|null $transfer_account_code_prefix TRIAL
 * @property int|null $account_sale_tax_id TRIAL
 * @property int|null $account_purchase_tax_id TRIAL
 * @property int|null $tax_cash_basis_journal_id TRIAL
 * @property string|null $tax_calculation_rounding_method TRIAL
 * @property int|null $currency_exchange_journal_id TRIAL
 * @property int|null $anglo_saxon_accounting TRIAL
 * @property int|null $property_stock_account_input_categ_id TRIAL
 * @property int|null $property_stock_account_output_categ_id TRIAL
 * @property int|null $property_stock_valuation_account_id TRIAL
 * @property int|null $tax_exigibility TRIAL
 * @property string|null $account_bank_reconciliation_start TRIAL
 * @property int|null $incoterm_id TRIAL
 * @property int|null $qr_code TRIAL
 * @property int|null $invoice_is_email TRIAL
 * @property int|null $invoice_is_print TRIAL
 * @property int|null $account_opening_move_id TRIAL
 * @property string|null $account_setup_bank_data_state TRIAL
 * @property string|null $account_setup_fy_data_state TRIAL
 * @property string|null $account_setup_coa_state TRIAL
 * @property string|null $account_onboarding_invoice_layout_state TRIAL
 * @property string|null $account_onboarding_sample_invoice_state TRIAL
 * @property string|null $account_onboarding_sale_tax_state TRIAL
 * @property string|null $account_invoice_onboarding_state TRIAL
 * @property string|null $account_dashboard_onboarding_state TRIAL
 * @property string|null $invoice_terms TRIAL
 * @property int|null $account_default_pos_receivable_account_id TRIAL
 * @property int|null $expense_accrual_account_id TRIAL
 * @property int|null $revenue_accrual_account_id TRIAL
 * @property int|null $accrual_default_journal_id TRIAL
 * @property string|null $payment_acquirer_onboarding_state TRIAL
 * @property string|null $payment_onboarding_payment_method TRIAL
 * @property int|null $invoice_is_snailmail TRIAL
 * @property int|null $vat_check_vies TRIAL
 * @property float $manufacturing_lead TRIAL
 * @property int|null $portal_confirmation_sign TRIAL
 * @property int|null $portal_confirmation_pay TRIAL
 * @property int|null $quotation_validity_days TRIAL
 * @property string|null $sale_quotation_onboarding_state TRIAL
 * @property string|null $sale_onboarding_order_confirmation_state TRIAL
 * @property string|null $sale_onboarding_sample_quotation_state TRIAL
 * @property string|null $sale_onboarding_payment_method TRIAL
 * @property float $security_lead TRIAL
 * @property string|null $website_sale_onboarding_payment_acquirer_state TRIAL
 * @property float $po_lead TRIAL
 * @property string|null $po_lock TRIAL
 * @property string|null $po_double_validation TRIAL
 * @property float|null $po_double_validation_amount TRIAL
 * @property int|null $hr_presence_control_email_amount TRIAL
 * @property string|null $hr_presence_control_ip_list TRIAL
 * @property string|null $trial415 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property CrmTeam[] $crmTeams
 * @property IrAttachment[] $irAttachments
 * @property ResUsers $createU
 * @property ResCompany $parent
 * @property ResCompany[] $resCompanies
 * @property ResPartner $partner
 * @property ResUsers $writeU
 * @property ResPartner[] $resPartners
 * @property ResPartnerBank[] $resPartnerBanks
 * @property ResUsers[] $resUsers
 * @property SaleOrder[] $saleOrders
 * @property SaleOrderLine[] $saleOrderLines
 * @property UtmCampaign[] $utmCampaigns
 */
class ResCompany extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'res_company';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['name', 'partner_id', 'currency_id', 'fiscalyear_last_day', 'fiscalyear_last_month', 'manufacturing_lead', 'security_lead', 'po_lead'], 'required'],
            [['name', 'report_header', 'report_footer', 'logo_web', 'account_no', 'email', 'phone', 'company_registry', 'base_onboarding_company_state', 'font', 'primary_color', 'secondary_color', 'social_twitter', 'social_facebook', 'social_github', 'social_linkedin', 'social_youtube', 'social_instagram', 'fiscalyear_last_month', 'bank_account_code_prefix', 'cash_account_code_prefix', 'transfer_account_code_prefix', 'tax_calculation_rounding_method', 'account_setup_bank_data_state', 'account_setup_fy_data_state', 'account_setup_coa_state', 'account_onboarding_invoice_layout_state', 'account_onboarding_sample_invoice_state', 'account_onboarding_sale_tax_state', 'account_invoice_onboarding_state', 'account_dashboard_onboarding_state', 'invoice_terms', 'payment_acquirer_onboarding_state', 'payment_onboarding_payment_method', 'sale_quotation_onboarding_state', 'sale_onboarding_order_confirmation_state', 'sale_onboarding_sample_quotation_state', 'sale_onboarding_payment_method', 'website_sale_onboarding_payment_acquirer_state', 'po_lock', 'po_double_validation', 'hr_presence_control_ip_list'], 'string'],
            [['partner_id', 'currency_id', 'sequence', 'parent_id', 'paperformat_id', 'external_report_layout_id', 'create_uid', 'write_uid', 'partner_gid', 'snailmail_color', 'snailmail_cover', 'snailmail_duplex', 'resource_calendar_id', 'nomenclature_id', 'internal_transit_location_id', 'stock_move_email_validation', 'stock_mail_confirmation_template_id', 'stock_move_sms_validation', 'stock_sms_confirmation_template_id', 'has_received_warning_stock_sms', 'fiscalyear_last_day', 'transfer_account_id', 'expects_chart_of_accounts', 'chart_template_id', 'default_cash_difference_income_account_id', 'default_cash_difference_expense_account_id', 'account_sale_tax_id', 'account_purchase_tax_id', 'tax_cash_basis_journal_id', 'currency_exchange_journal_id', 'anglo_saxon_accounting', 'property_stock_account_input_categ_id', 'property_stock_account_output_categ_id', 'property_stock_valuation_account_id', 'tax_exigibility', 'incoterm_id', 'qr_code', 'invoice_is_email', 'invoice_is_print', 'account_opening_move_id', 'account_default_pos_receivable_account_id', 'expense_accrual_account_id', 'revenue_accrual_account_id', 'accrual_default_journal_id', 'invoice_is_snailmail', 'vat_check_vies', 'portal_confirmation_sign', 'portal_confirmation_pay', 'quotation_validity_days', 'hr_presence_control_email_amount'], 'integer'],
            [['create_date', 'write_date', 'period_lock_date', 'fiscalyear_lock_date', 'tax_lock_date', 'account_bank_reconciliation_start'], 'safe'],
            [['manufacturing_lead', 'security_lead', 'po_lead', 'po_double_validation_amount'], 'number'],
            [['trial415'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['parent_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['parent_id' => 'id']],
            [['partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Name',
            'partner_id' => 'Partner ID',
            'currency_id' => 'Currency ID',
            'sequence' => 'Sequence',
            'create_date' => 'Create Date',
            'parent_id' => 'Parent ID',
            'report_header' => 'Report Header',
            'report_footer' => 'Report Footer',
            'logo_web' => 'Logo Web',
            'account_no' => 'Account No',
            'email' => 'Email',
            'phone' => 'Phone',
            'company_registry' => 'Company Registry',
            'paperformat_id' => 'Paperformat ID',
            'external_report_layout_id' => 'External Report Layout ID',
            'base_onboarding_company_state' => 'Base Onboarding Company State',
            'font' => 'Font',
            'primary_color' => 'Primary Color',
            'secondary_color' => 'Secondary Color',
            'create_uid' => 'Create Uid',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'social_twitter' => 'Social Twitter',
            'social_facebook' => 'Social Facebook',
            'social_github' => 'Social Github',
            'social_linkedin' => 'Social Linkedin',
            'social_youtube' => 'Social Youtube',
            'social_instagram' => 'Social Instagram',
            'partner_gid' => 'Partner Gid',
            'snailmail_color' => 'Snailmail Color',
            'snailmail_cover' => 'Snailmail Cover',
            'snailmail_duplex' => 'Snailmail Duplex',
            'resource_calendar_id' => 'Resource Calendar ID',
            'nomenclature_id' => 'Nomenclature ID',
            'internal_transit_location_id' => 'Internal Transit Location ID',
            'stock_move_email_validation' => 'Stock Move Email Validation',
            'stock_mail_confirmation_template_id' => 'Stock Mail Confirmation Template ID',
            'stock_move_sms_validation' => 'Stock Move Sms Validation',
            'stock_sms_confirmation_template_id' => 'Stock Sms Confirmation Template ID',
            'has_received_warning_stock_sms' => 'Has Received Warning Stock Sms',
            'fiscalyear_last_day' => 'Fiscalyear Last Day',
            'fiscalyear_last_month' => 'Fiscalyear Last Month',
            'period_lock_date' => 'Period Lock Date',
            'fiscalyear_lock_date' => 'Fiscalyear Lock Date',
            'tax_lock_date' => 'Tax Lock Date',
            'transfer_account_id' => 'Transfer Account ID',
            'expects_chart_of_accounts' => 'Expects Chart Of Accounts',
            'chart_template_id' => 'Chart Template ID',
            'bank_account_code_prefix' => 'Bank Account Code Prefix',
            'cash_account_code_prefix' => 'Cash Account Code Prefix',
            'default_cash_difference_income_account_id' => 'Default Cash Difference Income Account ID',
            'default_cash_difference_expense_account_id' => 'Default Cash Difference Expense Account ID',
            'transfer_account_code_prefix' => 'Transfer Account Code Prefix',
            'account_sale_tax_id' => 'Account Sale Tax ID',
            'account_purchase_tax_id' => 'Account Purchase Tax ID',
            'tax_cash_basis_journal_id' => 'Tax Cash Basis Journal ID',
            'tax_calculation_rounding_method' => 'Tax Calculation Rounding Method',
            'currency_exchange_journal_id' => 'Currency Exchange Journal ID',
            'anglo_saxon_accounting' => 'Anglo Saxon Accounting',
            'property_stock_account_input_categ_id' => 'Property Stock Account Input Categ ID',
            'property_stock_account_output_categ_id' => 'Property Stock Account Output Categ ID',
            'property_stock_valuation_account_id' => 'Property Stock Valuation Account ID',
            'tax_exigibility' => 'Tax Exigibility',
            'account_bank_reconciliation_start' => 'Account Bank Reconciliation Start',
            'incoterm_id' => 'Incoterm ID',
            'qr_code' => 'Qr Code',
            'invoice_is_email' => 'Invoice Is Email',
            'invoice_is_print' => 'Invoice Is Print',
            'account_opening_move_id' => 'Account Opening Move ID',
            'account_setup_bank_data_state' => 'Account Setup Bank Data State',
            'account_setup_fy_data_state' => 'Account Setup Fy Data State',
            'account_setup_coa_state' => 'Account Setup Coa State',
            'account_onboarding_invoice_layout_state' => 'Account Onboarding Invoice Layout State',
            'account_onboarding_sample_invoice_state' => 'Account Onboarding Sample Invoice State',
            'account_onboarding_sale_tax_state' => 'Account Onboarding Sale Tax State',
            'account_invoice_onboarding_state' => 'Account Invoice Onboarding State',
            'account_dashboard_onboarding_state' => 'Account Dashboard Onboarding State',
            'invoice_terms' => 'Invoice Terms',
            'account_default_pos_receivable_account_id' => 'Account Default Pos Receivable Account ID',
            'expense_accrual_account_id' => 'Expense Accrual Account ID',
            'revenue_accrual_account_id' => 'Revenue Accrual Account ID',
            'accrual_default_journal_id' => 'Accrual Default Journal ID',
            'payment_acquirer_onboarding_state' => 'Payment Acquirer Onboarding State',
            'payment_onboarding_payment_method' => 'Payment Onboarding Payment Method',
            'invoice_is_snailmail' => 'Invoice Is Snailmail',
            'vat_check_vies' => 'Vat Check Vies',
            'manufacturing_lead' => 'Manufacturing Lead',
            'portal_confirmation_sign' => 'Portal Confirmation Sign',
            'portal_confirmation_pay' => 'Portal Confirmation Pay',
            'quotation_validity_days' => 'Quotation Validity Days',
            'sale_quotation_onboarding_state' => 'Sale Quotation Onboarding State',
            'sale_onboarding_order_confirmation_state' => 'Sale Onboarding Order Confirmation State',
            'sale_onboarding_sample_quotation_state' => 'Sale Onboarding Sample Quotation State',
            'sale_onboarding_payment_method' => 'Sale Onboarding Payment Method',
            'security_lead' => 'Security Lead',
            'website_sale_onboarding_payment_acquirer_state' => 'Website Sale Onboarding Payment Acquirer State',
            'po_lead' => 'Po Lead',
            'po_lock' => 'Po Lock',
            'po_double_validation' => 'Po Double Validation',
            'po_double_validation_amount' => 'Po Double Validation Amount',
            'hr_presence_control_email_amount' => 'Hr Presence Control Email Amount',
            'hr_presence_control_ip_list' => 'Hr Presence Control Ip List',
            'trial415' => 'Trial415',
        ];
    }

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['company_id' => 'id']);
    }

    /**
     * Gets query for [[CrmTeams]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getCrmTeams()
    {
        return $this->hasMany(CrmTeam::className(), ['company_id' => 'id']);
    }

    /**
     * Gets query for [[IrAttachments]].
     *
     * @return \yii\db\ActiveQuery|IrAttachmentQuery
     */
    public function getIrAttachments()
    {
        return $this->hasMany(IrAttachment::className(), ['company_id' => 'id']);
    }

    /**
     * Gets query for [[CreateU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    /**
     * Gets query for [[Parent]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getParent()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'parent_id']);
    }

    /**
     * Gets query for [[ResCompanies]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getResCompanies()
    {
        return $this->hasMany(ResCompany::className(), ['parent_id' => 'id']);
    }

    /**
     * Gets query for [[Partner]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_id']);
    }

    /**
     * Gets query for [[WriteU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    /**
     * Gets query for [[ResPartners]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['company_id' => 'id']);
    }

    /**
     * Gets query for [[ResPartnerBanks]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerBankQuery
     */
    public function getResPartnerBanks()
    {
        return $this->hasMany(ResPartnerBank::className(), ['company_id' => 'id']);
    }

    /**
     * Gets query for [[ResUsers]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getResUsers()
    {
        return $this->hasMany(ResUsers::className(), ['company_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['company_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrderLines]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderLineQuery
     */
    public function getSaleOrderLines()
    {
        return $this->hasMany(SaleOrderLine::className(), ['company_id' => 'id']);
    }

    /**
     * Gets query for [[UtmCampaigns]].
     *
     * @return \yii\db\ActiveQuery|UtmCampaignQuery
     */
    public function getUtmCampaigns()
    {
        return $this->hasMany(UtmCampaign::className(), ['company_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return ResCompanyQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ResCompanyQuery(get_called_class());
    }
}
