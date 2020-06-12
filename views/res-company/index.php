<?php

use yii\helpers\Html;
use yii\grid\GridView;

/* @var $this yii\web\View */
/* @var $searchModel app\models\ResCompanySearch */
/* @var $dataProvider yii\data\ActiveDataProvider */

$this->title = 'Compañias';
$this->params['breadcrumbs'][] = $this->title;
?>
<div class="res-company-index">

    <h1><?= Html::encode($this->title) ?></h1>

    <p>
        <?= Html::a('Crear Compañia', ['create'], ['class' => 'btn btn-success']) ?>
    </p>

    <?php // echo $this->render('_search', ['model' => $searchModel]); ?>

    <?= GridView::widget([
        'dataProvider' => $dataProvider,
        'filterModel' => $searchModel,
        'columns' => [
            ['class' => 'yii\grid\SerialColumn'],

            //'id',
            'name:ntext',
            'email',
            'phone',
            'create_date',
            //'create_date',
            //'parent_id',
            //'report_header:ntext',
            //'report_footer:ntext',
            //'logo_web',
            //'account_no:ntext',
            //'email:ntext',
            //'phone:ntext',
            //'company_registry:ntext',
            //'paperformat_id',
            //'external_report_layout_id',
            //'base_onboarding_company_state:ntext',
            //'font:ntext',
            //'primary_color:ntext',
            //'secondary_color:ntext',
            //'create_uid',
            //'write_uid',
            //'write_date',
            //'social_twitter:ntext',
            //'social_facebook:ntext',
            //'social_github:ntext',
            //'social_linkedin:ntext',
            //'social_youtube:ntext',
            //'social_instagram:ntext',
            //'partner_gid',
            //'snailmail_color',
            //'snailmail_cover',
            //'snailmail_duplex',
            //'resource_calendar_id',
            //'nomenclature_id',
            //'internal_transit_location_id',
            //'stock_move_email_validation:email',
            //'stock_mail_confirmation_template_id',
            //'stock_move_sms_validation',
            //'stock_sms_confirmation_template_id',
            //'has_received_warning_stock_sms',
            //'fiscalyear_last_day',
            //'fiscalyear_last_month:ntext',
            //'period_lock_date',
            //'fiscalyear_lock_date',
            //'tax_lock_date',
            //'transfer_account_id',
            //'expects_chart_of_accounts',
            //'chart_template_id',
            //'bank_account_code_prefix:ntext',
            //'cash_account_code_prefix:ntext',
            //'default_cash_difference_income_account_id',
            //'default_cash_difference_expense_account_id',
            //'transfer_account_code_prefix:ntext',
            //'account_sale_tax_id',
            //'account_purchase_tax_id',
            //'tax_cash_basis_journal_id',
            //'tax_calculation_rounding_method:ntext',
            //'currency_exchange_journal_id',
            //'anglo_saxon_accounting',
            //'property_stock_account_input_categ_id',
            //'property_stock_account_output_categ_id',
            //'property_stock_valuation_account_id',
            //'tax_exigibility',
            //'account_bank_reconciliation_start',
            //'incoterm_id',
            //'qr_code',
            //'invoice_is_email:email',
            //'invoice_is_print',
            //'account_opening_move_id',
            //'account_setup_bank_data_state:ntext',
            //'account_setup_fy_data_state:ntext',
            //'account_setup_coa_state:ntext',
            //'account_onboarding_invoice_layout_state:ntext',
            //'account_onboarding_sample_invoice_state:ntext',
            //'account_onboarding_sale_tax_state:ntext',
            //'account_invoice_onboarding_state:ntext',
            //'account_dashboard_onboarding_state:ntext',
            //'invoice_terms:ntext',
            //'account_default_pos_receivable_account_id',
            //'expense_accrual_account_id',
            //'revenue_accrual_account_id',
            //'accrual_default_journal_id',
            //'payment_acquirer_onboarding_state:ntext',
            //'payment_onboarding_payment_method:ntext',
            //'invoice_is_snailmail',
            //'vat_check_vies',
            //'manufacturing_lead',
            //'portal_confirmation_sign',
            //'portal_confirmation_pay',
            //'quotation_validity_days',
            //'sale_quotation_onboarding_state:ntext',
            //'sale_onboarding_order_confirmation_state:ntext',
            //'sale_onboarding_sample_quotation_state:ntext',
            //'sale_onboarding_payment_method:ntext',
            //'security_lead',
            //'website_sale_onboarding_payment_acquirer_state:ntext',
            //'po_lead',
            //'po_lock:ntext',
            //'po_double_validation:ntext',
            //'po_double_validation_amount',
            //'hr_presence_control_email_amount:email',
            //'hr_presence_control_ip_list:ntext',
            //'trial415',

            ['class' => 'yii\grid\ActionColumn'],
        ],
    ]); ?>


</div>
