<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\SaleOrder;
class SaleOrderSearch extends SaleOrder
{
    public function rules()
    {
        return [
            [['id', 'campaign_id', 'source_id', 'medium_id', 'message_main_attachment_id', 'require_signature', 'require_payment', 'user_id', 'partner_id', 'partner_invoice_id', 'partner_shipping_id', 'pricelist_id', 'analytic_account_id', 'payment_term_id', 'fiscal_position_id', 'company_id', 'team_id', 'create_uid', 'write_uid', 'sale_order_template_id', 'incoterm', 'warehouse_id', 'procurement_group_id', 'opportunity_id', 'cart_recovery_email_sent', 'website_id'], 'integer'],
            [['access_token', 'name', 'origin', 'client_order_ref', 'reference', 'state', 'date_order', 'validity_date', 'create_date', 'invoice_status', 'note', 'signed_by', 'signed_on', 'commitment_date', 'write_date', 'picking_policy', 'effective_date', 'warning_stock', 'trial539', 'partner_name', 'partner_invoice_name', 'partner_shipping_name', 'company_name', 'team_name'], 'safe'],
            [['amount_untaxed', 'amount_tax', 'amount_total', 'currency_rate'], 'number'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = SaleOrder::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'campaign_id' => $this->campaign_id,
            'source_id' => $this->source_id,
            'medium_id' => $this->medium_id,
            'message_main_attachment_id' => $this->message_main_attachment_id,
            'date_order' => $this->date_order,
            'validity_date' => $this->validity_date,
            'require_signature' => $this->require_signature,
            'require_payment' => $this->require_payment,
            'create_date' => $this->create_date,
            'user_id' => $this->user_id,
            'partner_id' => $this->partner_id,
            'partner_name' => $this->partner_name,
            'partner_invoice_id' => $this->partner_invoice_id,
            'partner_invoice_name' => $this->partner_invoice_name,
            'partner_shipping_id' => $this->partner_shipping_id,
            'partner_shipping_name' => $this->partner_shipping_name,
            'pricelist_id' => $this->pricelist_id,
            'analytic_account_id' => $this->analytic_account_id,
            'amount_untaxed' => $this->amount_untaxed,
            'amount_tax' => $this->amount_tax,
            'amount_total' => $this->amount_total,
            'currency_rate' => $this->currency_rate,
            'payment_term_id' => $this->payment_term_id,
            'fiscal_position_id' => $this->fiscal_position_id,
            'company_id' => $this->company_id,
            'company_name' => $this->company_name,
            'team_id' => $this->team_id,
            'team_name' => $this->team_name,
            'signed_on' => $this->signed_on,
            'commitment_date' => $this->commitment_date,
            'create_uid' => $this->create_uid,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
            'sale_order_template_id' => $this->sale_order_template_id,
            'incoterm' => $this->incoterm,
            'warehouse_id' => $this->warehouse_id,
            'procurement_group_id' => $this->procurement_group_id,
            'effective_date' => $this->effective_date,
            'opportunity_id' => $this->opportunity_id,
            'cart_recovery_email_sent' => $this->cart_recovery_email_sent,
            'website_id' => $this->website_id,
        ]);

        $query->andFilterWhere(['like', 'access_token', $this->access_token])
            ->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'origin', $this->origin])
            ->andFilterWhere(['like', 'client_order_ref', $this->client_order_ref])
            ->andFilterWhere(['like', 'reference', $this->reference])
            ->andFilterWhere(['like', 'state', $this->state])
            ->andFilterWhere(['like', 'invoice_status', $this->invoice_status])
            ->andFilterWhere(['like', 'note', $this->note])
            ->andFilterWhere(['like', 'signed_by', $this->signed_by])
            ->andFilterWhere(['like', 'picking_policy', $this->picking_policy])
            ->andFilterWhere(['like', 'warning_stock', $this->warning_stock])
            ->andFilterWhere(['like', 'trial539', $this->trial539]);

        return $dataProvider;
    }
}
