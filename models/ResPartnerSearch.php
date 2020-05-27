<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ResPartner;

/**
 * ResPartnerSearch represents the model behind the search form of `app\models\ResPartner`.
 */
class ResPartnerSearch extends ResPartner
{
    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['id', 'company_id', 'title', 'parent_id', 'user_id', 'active', 'employee', 'state_id', 'country_id', 'is_company', 'industry_id', 'color', 'partner_share', 'commercial_partner_id', 'create_uid', 'write_uid', 'message_main_attachment_id', 'message_bounce', 'partner_gid', 'website_id', 'is_published', 'team_id', 'supplier_rank', 'customer_rank', 'customer'], 'integer'],
            [['name', 'create_date', 'display_name', 'date', 'ref', 'lang', 'tz', 'vat', 'website', 'comment', 'function', 'type', 'street', 'street2', 'zip', 'city', 'email', 'phone', 'mobile', 'commercial_company_name', 'company_name', 'write_date', 'email_normalized', 'signup_token', 'signup_type', 'signup_expiration', 'additional_info', 'phone_sanitized', 'calendar_last_notif_ack', 'picking_warn', 'picking_warn_msg', 'last_time_entries_checked', 'invoice_warn', 'invoice_warn_msg', 'sale_warn', 'sale_warn_msg', 'purchase_warn', 'purchase_warn_msg', 'website_meta_title', 'website_meta_description', 'website_meta_keywords', 'website_meta_og_img', 'website_description', 'website_short_description', 'trial496'], 'safe'],
            [['credit_limit', 'partner_latitude', 'partner_longitude', 'debit_limit'], 'number'],
        ];
    }

    /**
     * {@inheritdoc}
     */
    public function scenarios()
    {
        // bypass scenarios() implementation in the parent class
        return Model::scenarios();
    }

    /**
     * Creates data provider instance with search query applied
     *
     * @param array $params
     *
     * @return ActiveDataProvider
     */
    public function search($params)
    {
        $query = ResPartner::find();

        // add conditions that should always apply here

        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            // uncomment the following line if you do not want to return any records when validation fails
            // $query->where('0=1');
            return $dataProvider;
        }

        // grid filtering conditions
        $query->andFilterWhere([
            'id' => $this->id,
            'company_id' => $this->company_id,
            'create_date' => $this->create_date,
            'date' => $this->date,
            'title' => $this->title,
            'parent_id' => $this->parent_id,
            'user_id' => $this->user_id,
            'credit_limit' => $this->credit_limit,
            'active' => $this->active,
            'employee' => $this->employee,
            'state_id' => $this->state_id,
            'country_id' => $this->country_id,
            'partner_latitude' => $this->partner_latitude,
            'partner_longitude' => $this->partner_longitude,
            'is_company' => $this->is_company,
            'industry_id' => $this->industry_id,
            'color' => $this->color,
            'partner_share' => $this->partner_share,
            'commercial_partner_id' => $this->commercial_partner_id,
            'create_uid' => $this->create_uid,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
            'message_main_attachment_id' => $this->message_main_attachment_id,
            'message_bounce' => $this->message_bounce,
            'signup_expiration' => $this->signup_expiration,
            'partner_gid' => $this->partner_gid,
            'website_id' => $this->website_id,
            'is_published' => $this->is_published,
            'calendar_last_notif_ack' => $this->calendar_last_notif_ack,
            'team_id' => $this->team_id,
            'debit_limit' => $this->debit_limit,
            'last_time_entries_checked' => $this->last_time_entries_checked,
            'supplier_rank' => $this->supplier_rank,
            'customer_rank' => $this->customer_rank,
            'customer' => $this->customer,
        ]);

        $query->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'display_name', $this->display_name])
            ->andFilterWhere(['like', 'ref', $this->ref])
            ->andFilterWhere(['like', 'lang', $this->lang])
            ->andFilterWhere(['like', 'tz', $this->tz])
            ->andFilterWhere(['like', 'vat', $this->vat])
            ->andFilterWhere(['like', 'website', $this->website])
            ->andFilterWhere(['like', 'comment', $this->comment])
            ->andFilterWhere(['like', 'function', $this->function])
            ->andFilterWhere(['like', 'type', $this->type])
            ->andFilterWhere(['like', 'street', $this->street])
            ->andFilterWhere(['like', 'street2', $this->street2])
            ->andFilterWhere(['like', 'zip', $this->zip])
            ->andFilterWhere(['like', 'city', $this->city])
            ->andFilterWhere(['like', 'email', $this->email])
            ->andFilterWhere(['like', 'phone', $this->phone])
            ->andFilterWhere(['like', 'mobile', $this->mobile])
            ->andFilterWhere(['like', 'commercial_company_name', $this->commercial_company_name])
            ->andFilterWhere(['like', 'company_name', $this->company_name])
            ->andFilterWhere(['like', 'email_normalized', $this->email_normalized])
            ->andFilterWhere(['like', 'signup_token', $this->signup_token])
            ->andFilterWhere(['like', 'signup_type', $this->signup_type])
            ->andFilterWhere(['like', 'additional_info', $this->additional_info])
            ->andFilterWhere(['like', 'phone_sanitized', $this->phone_sanitized])
            ->andFilterWhere(['like', 'picking_warn', $this->picking_warn])
            ->andFilterWhere(['like', 'picking_warn_msg', $this->picking_warn_msg])
            ->andFilterWhere(['like', 'invoice_warn', $this->invoice_warn])
            ->andFilterWhere(['like', 'invoice_warn_msg', $this->invoice_warn_msg])
            ->andFilterWhere(['like', 'sale_warn', $this->sale_warn])
            ->andFilterWhere(['like', 'sale_warn_msg', $this->sale_warn_msg])
            ->andFilterWhere(['like', 'purchase_warn', $this->purchase_warn])
            ->andFilterWhere(['like', 'purchase_warn_msg', $this->purchase_warn_msg])
            ->andFilterWhere(['like', 'website_meta_title', $this->website_meta_title])
            ->andFilterWhere(['like', 'website_meta_description', $this->website_meta_description])
            ->andFilterWhere(['like', 'website_meta_keywords', $this->website_meta_keywords])
            ->andFilterWhere(['like', 'website_meta_og_img', $this->website_meta_og_img])
            ->andFilterWhere(['like', 'website_description', $this->website_description])
            ->andFilterWhere(['like', 'website_short_description', $this->website_short_description])
            ->andFilterWhere(['like', 'trial496', $this->trial496]);

        return $dataProvider;
    }
}
