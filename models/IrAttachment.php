<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "ir_attachment".
 *
 * @property int $id TRIAL
 * @property string $name TRIAL
 * @property string|null $description TRIAL
 * @property string|null $res_model TRIAL
 * @property string|null $res_field TRIAL
 * @property int|null $res_id TRIAL
 * @property int|null $company_id TRIAL
 * @property string $type TRIAL
 * @property string|null $url TRIAL
 * @property int|null $public TRIAL
 * @property string|null $access_token TRIAL
 * @property resource|null $db_datas TRIAL
 * @property string|null $store_fname TRIAL
 * @property int|null $file_size TRIAL
 * @property string|null $checksum TRIAL
 * @property string|null $mimetype TRIAL
 * @property string|null $index_content TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $key TRIAL
 * @property int|null $website_id TRIAL
 * @property int|null $theme_template_id TRIAL
 * @property string|null $trial313 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property CrmTeam[] $crmTeams
 * @property ResCompany $company
 * @property ResUsers $createU
 * @property ResUsers $writeU
 * @property ProductProduct[] $productProducts
 * @property ResPartner[] $resPartners
 * @property SaleOrder[] $saleOrders
 */
class IrAttachment extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'ir_attachment';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['name', 'type'], 'required'],
            [['name', 'description', 'res_model', 'res_field', 'type', 'access_token', 'db_datas', 'store_fname', 'mimetype', 'index_content', 'key'], 'string'],
            [['res_id', 'company_id', 'public', 'file_size', 'create_uid', 'write_uid', 'website_id', 'theme_template_id'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['url'], 'string', 'max' => 1024],
            [['checksum'], 'string', 'max' => 40],
            [['trial313'], 'string', 'max' => 1],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
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
            'description' => 'Description',
            'res_model' => 'Res Model',
            'res_field' => 'Res Field',
            'res_id' => 'Res ID',
            'company_id' => 'Company ID',
            'type' => 'Type',
            'url' => 'Url',
            'public' => 'Public',
            'access_token' => 'Access Token',
            'db_datas' => 'Db Datas',
            'store_fname' => 'Store Fname',
            'file_size' => 'File Size',
            'checksum' => 'Checksum',
            'mimetype' => 'Mimetype',
            'index_content' => 'Index Content',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'key' => 'Key',
            'website_id' => 'Website ID',
            'theme_template_id' => 'Theme Template ID',
            'trial313' => 'Trial313',
        ];
    }

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['message_main_attachment_id' => 'id']);
    }

    /**
     * Gets query for [[CrmTeams]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getCrmTeams()
    {
        return $this->hasMany(CrmTeam::className(), ['message_main_attachment_id' => 'id']);
    }

    /**
     * Gets query for [[Company]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
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
     * Gets query for [[WriteU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    /**
     * Gets query for [[ProductProducts]].
     *
     * @return \yii\db\ActiveQuery|ProductProductQuery
     */
    public function getProductProducts()
    {
        return $this->hasMany(ProductProduct::className(), ['message_main_attachment_id' => 'id']);
    }

    /**
     * Gets query for [[ResPartners]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['message_main_attachment_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['message_main_attachment_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return IrAttachmentQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new IrAttachmentQuery(get_called_class());
    }
}
