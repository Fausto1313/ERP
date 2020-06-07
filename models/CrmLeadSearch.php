<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\CrmLead;

class CrmLeadSearch extends CrmLead
{
    public function rules()
    {
        return [
            [['id','email_cc', 'email_normalized', 'name', 'email_from', 'website', 'description', 'contact_name', 'partner_name', 'type', 'priority', 'referred', 'phone_state', 'email_state', 'street', 'street2', 'zip', 'city', 'phone', 'mobile', 'function'], 'string'],
            [['message_main_attachment_id', 'message_bounce', 'campaign_id', 'source_id', 'medium_id', 'partner_id', 'active', 'team_id', 'stage_id', 'user_id', 'color', 'state_id', 'country_id', 'lang_id', 'title', 'company_id', 'lost_reason', 'create_uid', 'write_uid'], 'integer'],
            [['email_cc'], 'required'],
            [['date_action_last', 'date_closed', 'date_open', 'date_last_stage_update', 'date_conversion', 'date_deadline', 'create_date', 'write_date'], 'safe'],
            [['day_open', 'day_close', 'probability', 'automated_probability', 'planned_revenue', 'expected_revenue'], 'number'],
        ];

    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = CrmLead::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            
            
           'id' => $this->id,
            'email_cc' => $this->email_cc,
            'message_main_attachment_id' => $this->message_main_attachment_id,
            'message_bounce' => $this->message_bounce,
            'email_normalized' =>$this->email_normalized,
            'campaign_id' => $this->campaign_id,
            'source_id' =>$this->source_id,
            'medium_id' => $this->medium_id,
            'name' => $this->name,
            'partner_id' => $this->partner_id,
            'active' => $this->active,
            'date_action_last' =>$this->date_action_last,
            'email_from' =>$this->email_from,
            'website' =>$this->website,
            'team_id' =>$this->team_id,
            'description' => $this->description,
            'contact_name' =>$this->contact_name,
            'partner_name' => $this->partner_name,
            'type' => $this->type,
            'priority' => $this->priority,
            'date_closed' => $this->date_closed,
            'stage_id' => $this->stage_id,
            'user_id' =>$this->user_id,
            'referred' => $this->referred,
            'date_open' =>$this->date_open,
            'day_open' =>$this->day_open,
            'day_close' =>$this->day_close,
            'date_last_stage_update' =>$this->date_last_Stage_update,
            'date_conversion' =>$this->date_conversion,
            'probability' => $this->probability,
            'automated_probability' => $this->automated_probability,
            'phone_state' => $this->phone_state,
            'email_state' => $this->email_State,
            'planned_revenue' => $this->planned_revenue,
            'expected_revenue' => $this->expected_revenue,
            'date_deadline' =>$this->date_deadline,
            'color' => $this->color,
            'street' =>$this->street,
            'street2' =>$this->street2,
            'zip' => $this->zip,
            'city' => $this->city,
            'state_id' => $this->state_id,
            'country_id' =>$this->country_id,
            'lang_id' =>$this->lang_id,
            'phone' => $this->phone,
            'mobile' => $this->mobile,
            'function' =>$this->function,
            'title' => $this->title,
            'company_id' => $this->company_id,
            'lost_reason' => $this->lost_Reason,
            'create_uid' =>$this->create_uid,
            'create_date' => $this->create_date,
            'write_uid' =>$this->write_uid,
            'write_date' =>$this->write_date,
            
            
        ]);


        $query->andFilterWhere(['like', 'id', $this->id])
            ->andFilterWhere(['like', 'email_cc', $this->email_cc])
            ->andFilterWhere(['like', 'message_main_attachment_id', $this->message_main_attachment_id])
            ->andFilterWhere(['like', 'message_bounce', $this->message_bounce])
            ->andFilterWhere(['like', 'email_normalized', $this->email_normalized])
            ->andFilterWhere(['like', 'campaign_id', $this->campaign_id])
            ->andFilterWhere(['like', 'source_id', $this->source_id])
            ->andFilterWhere(['like', 'medium_id', $this->medium_id])
            ->andFilterWhere(['like', 'name', $this->name])
            ->andFilterWhere(['like', 'partner_id', $this->partner_id])
            ->andFilterWhere(['like', 'active', $this->active])
            ->andFilterWhere(['like', 'date_action_last', $this->date_action_last])
            ->andFilterWhere(['like', 'email_from', $this->email_from])
            ->andFilterWhere(['like', 'vat', $this->vat])
            ->andFilterWhere(['like', 'website', $this->website])
            ->andFilterWhere(['like', 'team_id', $this->team_id])
            ->andFilterWhere(['like', 'description', $this->description])
            ->andFilterWhere(['like', 'contact_name', $this->contact_name])
            ->andFilterWhere(['like', 'partner_name', $this->partner_name])
            ->andFilterWhere(['like', 'type', $this->type])
            ->andFilterWhere(['like', 'priority', $this->priority])
            ->andFilterWhere(['like', 'date_closed', $this->date_closed])
            ->andFilterWhere(['like', 'stage_id', $this->stage_id])
            ->andFilterWhere(['like', 'user_id', $this->user_id])
            ->andFilterWhere(['like', 'referred', $this->referred])
            ->andFilterWhere(['like', 'date_open', $this->date_open])
            ->andFilterWhere(['like', 'day_open', $this->day_open])
            ->andFilterWhere(['like', 'day_close', $this->day_close])
            ->andFilterWhere(['like', 'date_last_stage_update', $this->date_last_stage_update])
            ->andFilterWhere(['like', 'date_conversion', $this->date_conversion])
            ->andFilterWhere(['like', 'probability', $this->probability])
            ->andFilterWhere(['like', 'automated_probability', $this->automated_probability])
            ->andFilterWhere(['like', 'phone_state', $this->phone_state])
            ->andFilterWhere(['like', 'email_state', $this->email_state])
            ->andFilterWhere(['like', 'planned_revenue', $this->planned_revenue])
            ->andFilterWhere(['like', 'expected_revenue', $this->expected_revenue])
            ->andFilterWhere(['like', 'date_deadline', $this->date_deadline])
            ->andFilterWhere(['like', 'color', $this->color])
            ->andFilterWhere(['like', 'street', $this->street])
            ->andFilterWhere(['like', 'street2', $this->street2])
            ->andFilterWhere(['like', 'zip', $this->zip])
            ->andFilterWhere(['like', 'city', $this->city])
            ->andFilterWhere(['like', 'state_id', $this->state_id])
            ->andFilterWhere(['like', 'country_id', $this->country_id])
            ->andFilterWhere(['like', 'lang_id', $this->lang_id])
            ->andFilterWhere(['like', 'phone', $this->phone])
            ->andFilterWhere(['like', 'mobile', $this->mobile])
            ->andFilterWhere(['like', 'function', $this->function])
            ->andFilterWhere(['like', 'title', $this->title])
            ->andFilterWhere(['like', 'company_id', $this->company_id])
            ->andFilterWhere(['like', 'lost_reason', $this->lost_reason])
            ->andFilterWhere(['like', 'create_uid', $this->create_uid])
            ->andFilterWhere(['like', 'create_date', $this->create_date])
            ->andFilterWhere(['like', 'write_uid', $this->write_uid])
            ->andFilterWhere(['like', 'write_date', $this->write_date])
            ->andFilterWhere(['like', 'trial242', $this->trial242]);

        return $dataProvider;
    }
}
